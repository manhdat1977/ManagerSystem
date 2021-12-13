<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="giadinhGIS.aspx.cs" Inherits="ManagerSystem.giadinhGIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="https://js.arcgis.com/4.3/esri/css/main.css">
	<script src="https://js.arcgis.com/4.3/"></script>
	<style>
	html, body {margin: 0;padding: 0;width: 100%;height: 100%;}
	#ui-map-view {width: 100%;height: 100%;}
 	.gdw-theme .esri-widget,
    .gdw-theme .esri-widget-button,
    .gdw-theme .esri-menu,
    .gdw-theme .esri-popup__main-container,
    .gdw-theme .esri-popup .esri-pointer-direction,
    .gdw-theme .esri-button {background-color: #fcfce0; color: #000000;}
    
    .gdw-theme .esri-widget-button:focus,
    .gdw-theme .esri-widget-button:hover,
    .gdw-theme .esri-menu li:focus,
    .gdw-theme .esri-menu li:hover {background-color: #72d7ff; color: #000000;}
    
    .gdw-theme .esri-button:focus,
    .gdw-theme .esri-button:hover {color: #000000;}

	</style>
	<script>
	    require([
"esri/Map",
"esri/views/MapView",
"esri/layers/MapImageLayer",
"esri/layers/FeatureLayer",
"esri/widgets/Expand",
"esri/widgets/Compass",
"esri/widgets/LayerList",
"esri/widgets/Legend",
"esri/widgets/Home",
"esri/widgets/Compass",
"esri/widgets/Locate",
"esri/widgets/Search",
"esri/widgets/Print",
"esri/tasks/IdentifyTask",
"esri/tasks/support/IdentifyParameters",
"esri/symbols/PictureMarkerSymbol",
"esri/Graphic",
"esri/layers/GraphicsLayer",
"esri/symbols/SimpleFillSymbol",
"esri/symbols/SimpleLineSymbol",
"esri/symbols/SimpleMarkerSymbol",
"esri/request",
"dojo/_base/array",
"dojo/dom",
"dojo/on",
"dojo/domReady!"
], function (Map, MapView, MapImageLayer, FeatureLayer,
			 Expand, Compass, LayerList, Legend, Home, Compass, Locate, Search, Print,
			 IdentifyTask, IdentifyParameters,
	         PictureMarkerSymbol, Graphic, GraphicsLayer, SimpleFillSymbol, SimpleLineSymbol, SimpleMarkerSymbol,
	         esriRequest,
	         arrayUtils, dom, on) {

    /********************
    * Add Data
    ********************/
    // Create var
    var url_network = "http://192.168.23.159:6080/arcgis/rest/services/CapNuocGiaDinh/MapServer";
    var layer_network = new MapImageLayer({ url: url_network, title: 'Há»‡ Thá»‘ng Cáº¥p NÆ°á»›c', opacity: 1 });
    var url_basemap = "http://192.168.23.159:6080/arcgis/rest/services/DiaChinh/MapServer";
    var layer_basemap = new MapImageLayer({ url: url_basemap, title: 'Báº£n Äá»“ Ná»n', opacity: 1 });
    var url_dma = "http://192.168.23.159:6080/arcgis/rest/services/DMA/MapServer";
    var layer_dma = new MapImageLayer({ url: url_dma, title: 'Ranh VÃ¹ng DMA', opacity: 0.6 });
    var url_boundary = "http://192.168.23.159:6080/arcgis/rest/services/RanhHanhChinh/MapServer";
    var layer_boundary = new MapImageLayer({ url: url_boundary, title: 'Ranh HÃ nh ChÃ­nh', opacity: 1 });
    var url_dhkh84 = "http://192.168.23.159:6080/arcgis/rest/services/DHKHWGS84WEB/MapServer";
    var layer_dhkh84 = new MapImageLayer({ url: url_dhkh84 });

    // Add map => view
    var map = new Map({ layers: [layer_dma, layer_boundary, layer_basemap, layer_network] });
    var view = new MapView({ map: map, center: [106.70, 10.81], zoom: 14, container: "ui-map-view" });
    /********************
    * Add widgets
    ********************/
    var location = new PictureMarkerSymbol({ url: "location.png", size: 25, width: 25, height: 25, xoffset: 0, yoffset: 25, angle: 0 });
    var markerSymbol = new SimpleMarkerSymbol({ style: "cicle", color: [155, 255, 255], size: "16px", outline: { color: [0, 255, 255], width: 2} });
    var fillSymbol = new SimpleFillSymbol({ color: [150, 255, 255, 1], style: "none", outline: { color: [0, 255, 255, 1], width: 2} });
    // widget Home
    var homeBtnWidget = new Home({ view: view });
    view.ui.add(homeBtnWidget, "top-left");
    // widget layerList
    var layerListWidget = new LayerList({ view: view });
    var expand_layerListWidget = new Expand({ view: view, content: layerListWidget, expandTooltip: "Táº¯t/Má»Ÿ Lá»›p Dá»¯ Liá»‡u", expandIconClass: "esri-icon-layers" });
    view.ui.add(expand_layerListWidget, "top-left");
    // widget Legend
    var legendWidget = new Legend({ view: view, layerInfos: [{ layer: layer_network, title: "Báº£ng ChÃº ThÃ­ch"}] });
    var expand_legendWidget = new Expand({ view: view, content: legendWidget, expandTooltip: "ChÃº ThÃ­ch KÃ½ Hiá»‡u", expandIconClass: "esri-icon-environment-settings" });
    view.ui.add(expand_legendWidget, "top-left");
    // widget Locate
    var locateBtn = new Locate({ view: view, graphic: Graphic({ symbol: location }) });
    view.ui.add(locateBtn, { position: "top-left" });
    // widget Search
    var searchWidget = new Search({ view: view, allPlaceholder: "Nháº­p ThÃ´ng Tin Cáº§n TÃ¬m" });
    var sources = [
    	{
    	    featureLayer: new FeatureLayer({ url: "http://192.168.23.159:6080/arcgis/rest/services/DHKHWGS84WMAS/MapServer/0" }),
    	    searchFields: ["DBDongHoNuoc"],
    	    suggestionTemplate: "{Danh Báº¡}",
    	    exactMatch: true,
    	    popupEnabled: false,
    	    outFields: ["*"],
    	    zoomScale: 100,
    	    resultSymbol: location,
    	    name: "TÃ¬m Danh Báº¡",
    	    placeholder: "Nháº­p Danh Báº¡"
    	}];
    searchWidget.sources = sources;
    var expand_searchWidget = new Expand({ view: view, content: searchWidget, expandTooltip: "TÃ¬m Kiáº¿m ThÃ´ng Tin", expandIconClass: "esri-icon-search" });
    view.ui.add(expand_searchWidget, "top-left");
    // widget Compass
    var compassWidget = new Compass({ view: view });
    view.ui.add(compassWidget, { position: "bottom-right" });
    // widget Print
    var printWidget = new Print({ view: view, printServiceUrl: "http://192.168.23.159:6080/arcgis/rest/services/Utilities/PrintingTools/GPServer/Export%20Web%20Map%20Task" });
    var expand_printWidget = new Expand({ view: view, content: printWidget, expandTooltip: "In áº¤n", expandIconClass: "esri-icon-printer" });
    view.ui.add(expand_printWidget, "bottom-left");

    /********************
    * Add Identify
    ********************/
    var identifyTask, params;
    view.then(function () {
        on(view, "click", executeIdentifyTask);
        identifyTask = new IdentifyTask(url_network);
        params = new IdentifyParameters();
        params.tolerance = 5;
        params.layerIds = [0, 1, 2, 3, 4, 5, 6, 7, 8];
        params.layerOption = "visible"; ;
        params.width = view.width;
        params.height = view.height;
        params.returnGeometry = true;
    });

    function executeIdentifyTask(event) {
        params.geometry = event.mapPoint;
        params.mapExtent = view.extent;
        dom.byId("ui-map-view").style.cursor = "wait";

        identifyTask.execute(params).then(function (response) {
            var results = response.results;
            return arrayUtils.map(results, function (result) {
                var feature = result.feature;
                var layerName = result.layerName;
                feature.attributes.layerName = layerName;

                if (layerName === 'Äá»“ng Há»“ KhÃ¡ch HÃ ng') {
                    feature.popupTemplate = { title: "THÃ”NG TIN KHÃCH HÃ€NG", content:
	"<b>Danh Báº¡: </b> {Danh Báº¡}" +
	"<br><b>KhÃ¡ch HÃ ng: </b> {TÃªn ThuÃª Bao}" +
	"<br><b>Sá»‘ NhÃ : </b> {Sá»‘ NhÃ }" +
	"<br><b>TÃªn ÄÆ°á»ng: </b> {TÃªn ÄÆ°á»ng}" +
	"<br><b>Cá»¡ Äá»“ng Há»“: </b> {Cá»¡ Äá»“ng Há»“}" +
	"<br><b>Hiá»‡u Äá»“ng Há»“: </b> {MÃ£ Hiá»‡u}" +
	"<br><b>Vá»‹ TrÃ­ Láº¯p Äáº·t: </b> {Vá»‹ TrÃ­ Láº¯p Äáº·t}"
                    };
                }
                return feature;
            });
        }).then(showPopup);

        // HÃ m hiá»‡n Popup
        function showPopup(response) {
            if (response.length > 0) {
                view.popup.open({ features: response, location: event.mapPoint });
                //show highlight
                var graphics = arrayUtils.map(response, function (item) {
                    //if (response.type === "polygon") {}
                    //else if (response.type === "polygon")}
                    var fillGraphic = new Graphic({ geometry: item.geometry, symbol: fillSymbol });
                    return fillGraphic;
                });
                view.graphics.removeAll();
                view.graphics.addMany(graphics);
            }
            dom.byId("ui-map-view").style.cursor = "auto";
        }
    }
});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	


<body class="gdw-theme">
	<div id="ui-map-view"> </div>
</body>
</asp:Content>
