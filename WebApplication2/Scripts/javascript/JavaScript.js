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
        var mines = $(".mine-wrapper").find("." + resourceName)
        $.each(mines, function (index, value) {
            var upgradeCompletion = new Date(parseInt($(value).find(".upgradeCompletion").text().trim()));//
            var start = new Date();//
            if (upgradeCompletion - start < 0) {//
                currentProduction += parseInt($(value).find(".hourProduction").text());
            }//
        });
        if(resourceName=="Wheat")
            var limit = parseInt($('.granaryMax').text());
        else
            var limit = parseInt($('.barnMax').text());
        var nextValue = (currentValue + ((start.getTime() - lastUpdate) / 1000 / 3600) * currentProduction).toFixed(4);
        if (limit < nextValue)
            nextValue = limit;
        $(".res-value." + resourceName).text(nextValue);
        $(".res-lastUpdate." + resourceName).text(start.strftime("%Y-%m-%d %H:%M:%S"));
    }

    setInterval(updateResources, 1000);

    var getMineDetailsHTML = function (mineId) {
        $('#mine-details-container > .content').empty();
        $('#mine-details-container > .content').load('/Mines/Details?mineId=' + mineId);
        $('#mine-details-container').removeClass('hidden');
    };

    $('.mine-details-btn').click(function (e) {
        var mineId = $(this).data('mine-id');
        getMineDetailsHTML(mineId);
    });

    $('#mine-details-container > .close-btn').click(function () {
        $('#mine-details-container').addClass('hidden');
    });

    var updateConstructionTime = function() {

        var constructions = $(".mine-wrapper").find(".time-detail")
        $.each(constructions, function (index, value) {
            var upgradeCompletion = new Date($(this).data('upgrade-completion'));
            var start = new Date();
            var nextTime = upgradeCompletion - start;
            if (nextTime > 0)
                $(value).text(new Date(nextTime).toISOString().slice(11, -5));
            else
                $(this).hide();
        });
    }

    setInterval(updateConstructionTime, 1000);
});