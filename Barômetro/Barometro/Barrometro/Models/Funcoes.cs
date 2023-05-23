using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace Barrometro.Web.Models
{
    public class Funcoes
    {
        public static string GerarGraficoTemperatura(string titulo, string dados)
        {
            string graf = @"<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
                             <script type=""text/javascript"">
                                  google.charts.load('current', {'packages':['corechart']});
                                  google.charts.setOnLoadCallback(drawChart);

                          function drawChart() {
                            var data = google.visualization.arrayToDataTable([
                              ['Hora','Temperatura Máxima','Temperatura Atual']," + dados + @"
                            ]);

                            var options = {
                              title: '" + titulo + @"',
                              curveType: 'function',
                              legend: { position: 'bottom' }
                            };

                            var chart = new google.visualization.LineChart(document.getElementById('graficoLinha'));
                            chart.draw(data, options);
                          }
                        </script>
                        <div id=""graficoLinha"" style=""width: 900px; height: 500px""></div>
                        ";
            return graf;
        }
        public static string GerarGraficoHumidade(string titulo2, string dadosHumidade)
        {
            string graf = @"<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
                            <script type = ""text/javascript"">
                            google.charts.load('current', { 'packages':['gauge']});
                            google.charts.setOnLoadCallback(drawChart);

                            function drawChart()
                                {
                                     var data = google.visualization.arrayToDataTable([
                                        "+ dadosHumidade + @"
                                      ]);

                                      var options = {
                                         width: 500, height: 200,
                                         redFrom: 90, redTo: 100,
                                         yellowFrom: 70, yellowTo: 90,
                                         minorTicks: 5
                                        };

                                    var chart = new google.visualization.Gauge(document.getElementById('graficoHumidade'));

                                    chart.draw(data, options);
   
                                }
                        </script>
                        <div id=""graficoHumidade"" style=""width: 900px; height: 500px""></div>";
            return graf;
        }
    }
}
