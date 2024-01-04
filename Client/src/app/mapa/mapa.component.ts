import { Component, OnInit} from '@angular/core';
declare let $: any; 

@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.scss']
})
export class MapaComponent implements OnInit{
 
ngOnInit(){
  
  generateMap(current.id)
}

}
let visitorsData = {
  US: 398, // USA
  SA: 400, // Saudi Arabia
  CA: 1000, // Canada
  DE: 500, // Germany
  FR: 760, // France
  CN: 300, // China
  AU: 700, // Australia
  BR: 600, // Brazil
  IN: 800, // India
  GB: 320, // Great Britain
  RU: 3000 // Russia
}
let options = [
  {id: "world_en", display: "World"},
  {id: "dz_fr", display: "Algeria"},
  {id: "argentina_en", display: "Argentina"},
  {id: "brazil_br", display: "Brazil"},
  {id: "canada_en", display: "Canada"},
  {id: "croatia", display: "Croatia"},
  {id: "france_fr", display: "France"},
  {id: "germany_en", display: "Germany"},
  {id: "greece", display: "Greece"},
  {id: "indonesia_id", display: "Indonesia"},
  {id: "iran_ir", display: "Iran"},
  {id: "iraq", display: "Iraq"},
  {id: "russia_en", display: "Russian Federation"},
  {id: "serbia", display: "Serbia"},
  {id: "tunisia", display: "Tunisia"},
  {id: "turkey", display: "Turkey"},
  {id: "ukraine_ua", display: "Ukraine"},
  {id: "usa_en", display: "United States of America"},

  {id: "africa_en", display: "South Africa"},
  {id: "africa_en", display: "Lesotho"},
  {id: "africa_en", display: "Swaziland"},
  {id: "africa_en", display: "Namibia"},
  {id: "africa_en", display: "Botswana"},
  {id: "africa_en", display: "Zimbabwe"},
  {id: "africa_en", display: "Mozambique"},
  {id: "africa_en", display: "Madagascar"},
  {id: "africa_en", display: "Malawi"},
  {id: "africa_en", display: "Angola"},
  {id: "africa_en", display: "Zambia"},
  {id: "africa_en", display: "Tanzania"},
  {id: "africa_en", display: "Congo"},
  {id: "africa_en", display: "Gabon"},
  {id: "africa_en", display: "Equatorial Guinea"},
  {id: "africa_en", display: "Sao Tome and Principe"},
  {id: "africa_en", display: "Central African Republic"},
  {id: "africa_en", display: "Burundi"},
  {id: "africa_en", display: "Rwanda"},
  {id: "africa_en", display: "Uganda"},
  {id: "africa_en", display: "Kenya"},
  {id: "africa_en", display: "Somalia"},
  {id: "africa_en", display: "Ethiopia"},
  {id: "africa_en", display: "Djibouti"},
  {id: "africa_en", display: "Eritrea"},
  {id: "africa_en", display: "Sudan"},
  {id: "africa_en", display: "Chad"},
  {id: "africa_en", display: "Cameroon"},
  {id: "africa_en", display: "Nigeria"},
  {id: "africa_en", display: "Benin"},
  {id: "africa_en", display: "Togo"},
  {id: "africa_en", display: "Ghana"},
  {id: "africa_en", display: "Cote d'Ivoire"},
  {id: "africa_en", display: "Liberia"},
  {id: "africa_en", display: "Sierra Leone"},
  {id: "africa_en", display: "Guinea"},
  {id: "africa_en", display: "Guinea-Bissau"},
  {id: "africa_en", display: "Senegal"},
  {id: "africa_en", display: "Gambia"},
  {id: "africa_en", display: "Mali"},
  {id: "africa_en", display: "Burkina Faso"},
  {id: "africa_en", display: "Niger"},
  {id: "africa_en", display: "Mauritania"},
  {id: "africa_en", display: "Morocco"},
  {id: "africa_en", display: "Libya"},
  {id: "africa_en", display: "Egypt"},

  {id: "australia_en", display: "Australia"},
  {id: "australia_en", display: "Papua New Guinea"},
  {id: "australia_en", display: "Solomon Islands"},
  {id: "australia_en", display: "Vanuatu"},
  {id: "australia_en", display: "Fiji"},
  {id: "australia_en", display: "New Caledonia"},
  {id: "australia_en", display: "New Zealand"},

  {id: 'asia_en', display: 'China'}, 
  {id: 'asia_en', display: 'Kazakhstan'}, 
  {id: 'asia_en', display: 'Mongolia'}, 
  {id: 'asia_en', display: 'Uzbekistan'}, 
  {id: 'asia_en', display: 'Kyrgyz Republic'}, 
  {id: 'asia_en', display: 'North Korea'}, 
  {id: 'asia_en', display: 'South Korea'}, 
  {id: 'asia_en', display: 'Japan'}, 
  {id: 'asia_en', display: 'Israel'},
  {id: 'asia_en', display: 'Syrian Arab Republic'},
  {id: 'asia_en', display: 'Saudi Arabia'},
  {id: 'asia_en', display: 'Yemen'},
  {id: 'asia_en', display: 'Oman'},
  {id: 'asia_en', display: 'United Arab Emirates'},
  {id: 'asia_en', display: 'Turkmenistan'},
  {id: 'asia_en', display: 'India'},
  {id: 'asia_en', display: 'Nepal'},
  {id: 'asia_en', display: 'Bangladesh'},
  {id: 'asia_en', display: 'Taiwan'},
  {id: 'asia_en', display: 'Philippines'},
  {id: 'asia_en', display: 'Sri Lanka'},
  {id: 'asia_en', display: 'Pakistan'},
  {id: 'asia_en', display: 'Tajikistan'},
  {id: 'asia_en', display: 'Jordan'},
  {id: 'asia_en', display: 'Lebanon'},
  {id: 'asia_en', display: "Lao People's Democratic Republic"},
  {id: 'asia_en', display: 'Vietnam'},
  {id: 'asia_en', display: 'Myanmar'},
  {id: 'asia_en', display: 'Thailand'},
  {id: 'asia_en', display: 'Malaysia'},

  {id: "north-america_en", display: "Mexico"},
  {id: "north-america_en", display: "Greenland"},
  {id: "north-america_en", display: "Cuba"},
  {id: "north-america_en", display: "Bahamas"},
  {id: "north-america_en", display: "Haiti"},
  {id: "north-america_en", display: "Dominican Republic"},
  {id: "north-america_en", display: "Trinidad and Tobago"},
  {id: "north-america_en", display: "Nicaragua"},
  {id: "north-america_en", display: "Costa Rica"},
  {id: "north-america_en", display: "Panama"},

  {id: 'south-america_en', display: 'Falkland Islands'},
  {id: 'south-america_en', display: 'Chile'},
  {id: 'south-america_en', display: 'Uruguay'},
  {id: 'south-america_en', display: 'Bolivia'},
  {id: 'south-america_en', display: 'Paraguay'},
  {id: 'south-america_en', display: 'Peru'},
  {id: 'south-america_en', display: 'Ecuador'},
  {id: 'south-america_en', display: 'Colombia'},
  {id: 'south-america_en', display: 'Venezuela'},
  {id: 'south-america_en', display: 'Guyana'},
  {id: 'south-america_en', display: 'Suriname'},
  {id: 'south-america_en', display: 'French Guiana'},
];
let current = {id: "world_en", display: "World"};
function onClickRegion(id: string) {
  // Update current selection
  let value = options.find(
    (opt) => 
      opt.display=== id
   );
   if (value !== undefined){

     current = value
   }
  console.log(current, id);
  if (current !== undefined) {
    generateMap(current.id)

  }
 }

 function generateMap(id: string){
    $("#area-map").html("<div id='world-map'></div>");
    var $map = $('#world-map');
    $map.width("100%").height("100%");
    $map.html("");
    $('#world-map').vectorMap({
      map: current.id,
      backgroundColor: 'transparent',
      borderColor: '#00d5ff',
      borderOpacity: 0.25,
      borderWidth: 1,
      color: '#230036',
      hoverColor: '#00d5ff',
      selectedColor: '#b700ff',
      regionStyle: {
        initial: {
          fill: 'rgba(255, 255, 255, 0.7)',
          'fill-opacity': 1,
          stroke: 'rgba(0,0,0,.2)',
          'stroke-width': 1,
          'stroke-opacity': 1
        }
      },
      series: {
        regions: [{
          values: visitorsData,
          scale: ['#ffffff', '#0154ad'],
          normalizeFunction: 'polynomial'
        }]
      },
      onRegionLabelShow: function (e, el, code) {
        if (typeof visitorsData[code] !== 'undefined') {
          el.html(el.html() + ': ' + visitorsData[code] + ' new visitors')
        }
      },
      onRegionClick: function(element, code, region)
      {
        onClickRegion(region)
      }
    })
 }