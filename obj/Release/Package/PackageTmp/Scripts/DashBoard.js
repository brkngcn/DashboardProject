function GetRealtimeValues() {
    var url = '/Flink/GetRealTimeValue';
    //$('table').html("");
    //var thead = '<thead><tr><th scope="col">#</th><th scope="col">Telefon</th><th scope="col">Tarih/Saat</th><th scope="col">İl</th><th scope="col">İlçe</th><th scope="col">Açık Adres</th><th scope="col">Arıza İhbar</th><th scope="col">İşleme Al</th><th scope="col">İşl. Alan Kul.</th></tr ></thead >';
    //$('table').append(thead);
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
            //if (data.Result[item].UserId == "") {
            //    var deger = '<tbody><tr><td>' + data.Result[item].Id /*count*/ + '</td><td>' + data.Result[item].Phone + '</td><td>' + data.Result[item].InsertDate + '</td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="il_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="ilce_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="adres_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="ihbar_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" onClick="islemeAl(this.id)" id="' + data.Result[item].Guid + '"class="btn btn-warning">İşleme Al</button></td><td>' + data.Result[item].UserId + " - " + data.Result[item].ProcessingDate + '</td></tr></tbody>';
            //}
            //else {
            //    var deger = '<tbody><tr><td>' + data.Result[item].Id /*count*/ + '</td><td>' + data.Result[item].Phone + '</td><td>' + data.Result[item].InsertDate + '</td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="il_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="ilce_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="adres_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" class="btn btn-primary" onClick="playAudioFile(this.id)" id="ihbar_' + data.Result[item].Guid + '.wav">Play</button><button type="button" onClick="stopAudioFile()" class="btn btn-danger">Stop</button></td><td><button type="button" onClick="stopAudioFile()" class="btn btn-secondary disabled">İşleme Al</button></td><td><strong>' + data.Result[item].UserId + " - " + data.Result[item].ProcessingDate + '</strong></td></tr></tbody>';
            //}
            //$('table').append(deger);
            //count = count - 1;
        }
    }).done(function (data) {

        //$('myTable').DataTable();
        //MakePagedTable(currentPage);

    });

}