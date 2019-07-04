

    function CreateLabel(tooltipItem, data) { 
                      
        var label = data.labels[tooltipItem.index];
        var values = data.datasets[tooltipItem.datasetIndex].data;
        var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
        var total = 0;
        for (var i in values) { 
          total += values[i];
        }
        var percentage = Math.round((value / total) * 100);
        var totally = total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        return label + " : " + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + ' (' + percentage + '%)';

        // if (tooltipItem.datasetIndex < data.datasets.length - 1) {
        //   return label + " : " + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + ' (' + percentage + '%)';
        // } else {
        //   return [label + " : " + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + ' (' + percentage + '%)', "Total : " + totally];
        // }
      }

 
if(typeof Chart != "undefined"){
    $('.chart-widget').each(function() {
         var ChartWidget = $(this);
 
        var _data               = $(this).data(),
            type                = _data.chartType ? _data.chartType : 'pie',
            labels              = _data.labels ? _data.labels : [],
            backgrounds         = _data.colors ? _data.colors : ["#00c169", "#f6a417","#3e9fd9", "#D5573B","#12355B", "#97EAD2",  "#6699CC", "#3498DB"],
            backgroundsHover    = _data.colorsHover ? _data.colorsHover :  ["#0fe484", "#fab030" ,"#57b3e9", "#ee755a","#16406e", "#76ebca",   "#77b0e9", "#73bcec"],
            Values              = _data.chartValues ? _data.chartValues : [],
            legendPostion       = _data.legendPostion ?_data.legendPostion : "top",
            legendDisplay       = _data.legendDisplay ? _data.legendDisplay : false,
            legendFontFamily    = _data.legendFontfamily ?_data.legendFontfamily : "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
            legendFontColor     = _data.legendFontcolor ?_data.legendFontcolor : "black",
            borderWidth         = _data.borderWidth  ? _data.borderWidth : 1,
            borderColor         = _data.borderColor ? _data.borderColor : ["#ffffff" ,"#ffffff", "#ffffff","#ffffff", "#ffffff",   "#ffffff", "#ffffff"];
            var _defaultLegind ={
                position : legendPostion,
                display: legendDisplay,
                labels: {
                    fontFamily : legendFontFamily ,
                    fontColor: legendFontColor
                },
            };
        
        var legend = _data.legend ? _data.legend :_defaultLegind;
        var _defaultData = {
            labels:  labels,
            datasets: [{
                data: Values,
                backgroundColor: backgrounds ,
                hoverBackgroundColor: backgroundsHover, 
                borderWidth: borderWidth,
                borderColor: borderColor ,
            }]
        } ;

        var _defaultOptions =  {
            tooltips: {
                callbacks: {
                    label: CreateLabel
                }
            },
            legend :legend
        }; 
        var Data = _data.chartData ? _data.chartData : _defaultData;
        var Options = _data.chartOptions ? _data.chartOptions : _defaultOptions ;

        var chart = new Chart(ChartWidget,{
            type: type,
            data: Data,
            options:Options
        });
    })
} 
