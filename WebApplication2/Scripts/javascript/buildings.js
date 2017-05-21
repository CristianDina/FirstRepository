$(document).ready(function (){

    var getBuildingDetailsHTML = function (buildingId) {
        $('#mine-details-container > .content').empty();
        $('#mine-details-container > .content').load('/Buildings/Details?buildingId=' + buildingId);
        $('#mine-details-container').removeClass('hidden');
    };

    $('.mine-details-btn').click(function (e) {
        var buildingId = $(this).data('building-id');
        getBuildingDetailsHTML(buildingId);
    });

    $('#mine-details-container > .close-btn').click(function () {
        $('#mine-details-container').addClass('hidden');
    });

    $('.build-btn').click(function (e) {
        var buildingId = $(this).data('building-id');
        var cityId = $(this).data('city-id');
        build(buildingId, cityId);
    });
    var build = function (buildingId, cityId) {
        $('#mine-details-container > .content').empty();
        $('#mine-details-container > .content').load('/Buildings/Build?buildingId=' + buildingId+'&cityId='+cityId);
        $('#mine-details-container').removeClass('hidden');
    };
});