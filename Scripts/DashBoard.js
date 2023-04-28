function GetRealtimeValues() {
    var url = '/dashboardapi/GetRealTimeValue';
    
    console.log("GetRealtimeValues Callled");
    $.getJSON(url, function (data) {

        var count = data.Result.length;

        for (var item in data.Result) {

            const parent = document.querySelector('#' + data.Result[item].deviceID);
            const child1 = parent.querySelector('#temp');
            child1.innerHTML = data.Result[item].tempVal;
            const child2 = parent.querySelector('#hum');
            child2.innerHTML = data.Result[item].humVal;


            //document.getElementById(data.Result[item].deviceID).innerHTML = data.Result[item].tempVal;
            console.log("device ID");
            console.log(data.Result[item].deviceID);
            console.log("Temp");
            console.log(child1.innerHTML);
            console.log("Hum");
            console.log(child2.innerHTML);
           
        }
    }).done(function (data) {

       // do after done

    });

}