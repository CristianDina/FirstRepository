$(document).ready(function (){
    var updateResources = function () {
        updateResource("Clay");
        updateResource("Wood");
        updateResource("Iron");
        updateResource("Wheat");
    };
    var updateResource = function (resourceName) {
        var start = new Date();
        var currentProduction = 0;
        var currentValue = parseFloat($(".res-value." + resourceName).text());
        var lastUpdate = Date.parse($(".res-lastUpdate." + resourceName).text());
        var mines = $(".mines").find("." + resourceName)
        $.each(mines, function (index, value) {
            
            currentProduction += parseInt($(value).find(".hourProduction").text());
            console.log(currentProduction);
        });
        var nextValue = (currentValue + ((start.getTime() - lastUpdate) / 1000 / 3600) * currentProduction).toFixed(4);
        $(".res-value." + resourceName).text(nextValue);
        $(".res-lastUpdate." + resourceName).text(start.strftime("%Y-%m-%d %H:%M:%S"));
    }

    setInterval(updateResources, 1000);
});