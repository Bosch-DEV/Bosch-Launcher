using Bosch_Launcher.Windows;
using System.Net.Http;
using System.Net;
using System.Windows;
using System.Security;
using Markdig;

namespace Bosch_Launcher;
public static class Extensions {
    private static WebProxy? Proxy = null;
    public static async Task<byte[]?> Download (string url) {
        try {
            using var handler = new HttpClientHandler ();

            if (Proxy != null) {
                handler.Proxy = Proxy;
                handler.UseProxy = true;
            }

            using var client = new HttpClient (handler);
            return await client.GetByteArrayAsync (url);
        } catch (HttpRequestException ex) {
            if (ex.Message.Contains ("407") || ex.Message.Contains ("proxy")) {
                var uri = WebRequest.GetSystemWebProxy ().GetProxy (new Uri (url));
                if (uri != null && !uri.IsDefaultPort && uri.Host != new Uri (url).Host) {
                    if (Proxy == null) {
                        try {
                            var dialog = new Dialog (uri.ToString ());

                            if (dialog.ShowDialog () == true) {
                                Proxy = new WebProxy (uri) { Credentials = new NetworkCredential (Environment.UserName, dialog.Password) };
                            } else {
                                _ = MessageBox.Show ("Proxy access was cancelled by the user.");
                                return null;
                            }
                        } catch {
                            return null;
                        }
                    }

                    using var handler = new HttpClientHandler { Proxy = Proxy, UseProxy = true };
                    using var client = new HttpClient (handler);

                    try {
                        return await client.GetByteArrayAsync (url);
                    } catch (Exception innerEx) {
                        _ = MessageBox.Show ($"Error downloading data via proxy: {innerEx.Message}");
                        return null;
                    }
                }
            }

            _ = MessageBox.Show ($"Error downloading the data: {ex.Message}");
            return null;
        }
    }
    public static string Markdown (string text)
        => $@"
            <!DOCTYPE html>
            <html lang='de'>
                <head>
                    <meta charset='UTF-8'>
                    <title>Markdown Preview</title>
                    <style>
                        body {{
                            font-family: 'Segoe UI', sans-serif;
                            margin: 20px;
                            line-height: 1.6;
                        }}
                    </style>
                </head>
                <body>
                    {Markdig.Markdown.ToHtml (text, new MarkdownPipelineBuilder ().Build ())}
                </body>
            </html>";
    public static TResult Pipe<TInput, TResult> (this TInput input, Func<TInput, TResult> function)
        => function (input);
    public static void Pipe<TInput> (this TInput input, Action<TInput> action)
        => action (input);
}