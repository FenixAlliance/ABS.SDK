window.abs.navigator = {
    share: function (data) {
        navigator.share(data)
    },
}

window.abs.connection = {
    detectingConnectionChanges: false,
    detectConnectionChanges: function () {

        if (this.detectingConnectionChanges) return;

        let type = this.getConnectionType();
        function updateConnectionStatus() {
            console.log(`Connection type changed from ${type} to ${navigator.connection.effectiveType}`);
            type = navigator.connection.effectiveType;
        }
        navigator.connection.addEventListener("change", updateConnectionStatus);
        this.detectingConnectionChanges = true;
    },
    getConnectionType() {
        let type = navigator.connection.effectiveType;
        console.log(`Connection type: ${type}`);
        return type;
    }
}

window.abs.navigation = {
    openUrlNewTab: function (URL) {
        // implement

    }
}

window.abs.media = {
    playAudi: function (elementId)  {
        document.getElementById(elementId).play();
    }
}

window.abs.bluetooth = {

}

window.abs.geolocation = {
    latitude: "",
    longitude: "",
    getCurrentPosition: function () {

        function success(position) {
            window.abs.geolocation.latitude = position.coords.latitude;
            window.abs.geolocation.longitude = position.coords.longitude;
        }

        function error() {
            console.log("Unable to retrieve your location");
        }

        if (!navigator.geolocation) {
            console.log("Geolocation is not supported by your browser");
        } else {
            console.log( "Locating...");
            navigator.geolocation.getCurrentPosition(success, error);
        }
    }
}

window.abs.permissions = {

}

window.abs.battery = {

}

window.abs.usb = {

}

window.abs.pay = {
    paymentRequest: function (supportedInstruments, details, _requestShipping) {

        const options = { requestShipping: _requestShipping };

        try {
            const request = new PaymentRequest(supportedInstruments, details, options);
            // Add event listeners here.
            // Call show() to trigger the browser's payment flow.
            request
                .show()
                .then((instrumentResponse) => {
                    // Do something with the response from the UI.
                })
                .catch((err) => {
                    // Do something with the error from request.show().
                });
        } catch (e) {
            // Catch any other errors.
        }
    },
}