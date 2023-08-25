window.abs = window.abs || {};

window.abs.navigator = {
    share: function (data) {
        if (navigator.share) {
            navigator.share(data)
                .then(() => console.log('Content shared successfully'))
                .catch(error => console.error('An error occurred while sharing:', error));
        } else {
            console.warn('Web Share API is not supported in this browser.');
        }
    },
    getLanguage: function () {
        return navigator.language || navigator.userLanguage;
    },
    getUserAgent: function () {
        return navigator.userAgent;
    },
    getOnlineStatus: function () {
        return navigator.onLine;
    },
    vibrate: function (pattern) {
        if ("vibrate" in navigator) {
            return navigator.vibrate(pattern);
        } else {
            console.warn('Vibration API is not supported in this browser.');
            return false;
        }
    },
    getGeolocation: function (success, error) {
        if ("geolocation" in navigator) {
            navigator.geolocation.getCurrentPosition(success, error);
        } else {
            console.warn('Geolocation API is not supported in this browser.');
        }
    },
    requestMediaDevices: function () {
        return navigator.mediaDevices.getUserMedia({ audio: true, video: true })
            .then(stream => stream)
            .catch(error => console.error('An error occurred while accessing media devices:', error));
    },
    sendBeacon: function (url, data) {
        return navigator.sendBeacon(url, data);
    },
    getClipboard: async function () {
        if (!navigator.clipboard) {
            console.warn('Clipboard API is not supported in this browser.');
            return;
        }
        try {
            return await navigator.clipboard.readText();
        } catch (err) {
            console.error('An error occurred while accessing clipboard:', err);
        }
    },
    setClipboard: async function (text) {
        if (!navigator.clipboard) {
            console.warn('Clipboard API is not supported in this browser.');
            return;
        }
        try {
            await navigator.clipboard.writeText(text);
            console.log('Text copied to clipboard');
        } catch (err) {
            console.error('An error occurred while accessing clipboard:', err);
        }
    },
    getBatteryStatus: function () {
        return navigator.getBattery().then(battery => battery);
    },
};


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
        try {
            let win = window.open(URL, '_blank');
            if (win) {
                win.focus();
            } else {
                throw new Error("Pop-up blocked or failed to open.");
            }
        } catch (error) {
            console.error("Error opening URL in new tab:", error);
        }
    },
    redirectTo: function (URL) {
        try {
            window.location.href = URL;
        } catch (error) {
            console.error("Error redirecting to URL:", error);
        }
    },
    reload: function () {
        try {
            window.location.reload();
        } catch (error) {
            console.error("Error reloading page:", error);
        }
    },
    goBack: function () {
        try {
            window.history.back();
        } catch (error) {
            console.error("Error navigating back:", error);
        }
    },
    goForward: function () {
        try {
            window.history.forward();
        } catch (error) {
            console.error("Error navigating forward:", error);
        }
    },
    navigateTo: function (relativePath) {
        try {
            window.location.pathname = relativePath;
        } catch (error) {
            console.error("Error navigating to relative path:", error);
        }
    }
}

window.abs.media = {
    playAudio: function (elementId) {
        const audioElement = document.getElementById(elementId);
        if (audioElement && typeof audioElement.play === 'function') {
            audioElement.play().catch(error => console.error('An error occurred while playing audio:', error));
        } else {
            console.warn('Audio element not found or not playable.');
        }
    },
    pauseAudio: function (elementId) {
        const audioElement = document.getElementById(elementId);
        if (audioElement && typeof audioElement.pause === 'function') {
            audioElement.pause();
        } else {
            console.warn('Audio element not found or not pausable.');
        }
    },
    setVolume: function (elementId, volume) {
        const audioElement = document.getElementById(elementId);
        if (audioElement && typeof audioElement.volume === 'number') {
            audioElement.volume = Math.min(Math.max(volume, 0), 1);
        } else {
            console.warn('Audio element not found or volume not adjustable.');
        }
    },
    toggleMute: function (elementId) {
        const audioElement = document.getElementById(elementId);
        if (audioElement && typeof audioElement.muted === 'boolean') {
            audioElement.muted = !audioElement.muted;
        } else {
            console.warn('Audio element not found or mute property not accessible.');
        }
    },
    seekAudio: function (elementId, time) {
        const audioElement = document.getElementById(elementId);
        if (audioElement && typeof audioElement.currentTime === 'number') {
            audioElement.currentTime = time;
        } else {
            console.warn('Audio element not found or seek operation not possible.');
        }
    },
}

window.abs.bluetooth = {
    connect: function () {
        // Implement code to connect to a Bluetooth device
        return navigator.bluetooth.requestDevice({ filters: [{ services: ['battery_service'] }] })
            .then(device => device.gatt.connect())
            .catch(error => console.error(error));
    },
    disconnect: function (device) {
        // Implement code to disconnect a Bluetooth device
        if (device.gatt.connected) {
            device.gatt.disconnect();
        }
    },
    readCharacteristic: function (device, serviceUuid, characteristicUuid) {
        // Implement code to read a characteristic from a Bluetooth device
        return device.gatt.getPrimaryService(serviceUuid)
            .then(service => service.getCharacteristic(characteristicUuid))
            .then(characteristic => characteristic.readValue())
            .then(value => value.getUint8(0)) // Example of reading a Uint8 value
            .catch(error => console.error(error));
    },
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
    query: function (permissionName) {
        return navigator.permissions.query({ name: permissionName })
            .then(permissionStatus => {
                return {
                    state: permissionStatus.state // "granted", "denied", or "prompt"
                };
            })
            .catch(error => console.error(error));
    },
    request: function (permissionName) {
        // This method is a placeholder; the actual request for permission is usually done through specific APIs.
        switch (permissionName) {
        case 'geolocation':
            return new Promise((resolve, reject) => {
                navigator.geolocation.getCurrentPosition(
                    () => resolve({ state: 'granted' }),
                    () => reject({ state: 'denied' })
                );
            });
        case 'notifications':
            return Notification.requestPermission()
                .then(state => ({ state: state }));
        case 'camera':
        case 'microphone':
            return navigator.mediaDevices.getUserMedia({ video: permissionName === 'camera', audio: permissionName === 'microphone' })
                .then(() => ({ state: 'granted' }))
                .catch(() => ({ state: 'denied' }));
        case 'clipboard-read':
        case 'clipboard-write':
            return navigator.clipboard.readText() // or writeText
                .then(() => ({ state: 'granted' }))
                .catch(() => ({ state: 'denied' }));
        // Add cases for other permissions as needed
        default:
            return Promise.reject({ state: 'denied', message: 'Permission not handled' });
        }
    },
    // Add more permission-related functions as needed
}

window.abs.battery = {
    getStatus: function () {
        return navigator.getBattery()
            .then(battery => {
                return {
                    level: battery.level,
                    charging: battery.charging,
                    chargingTime: battery.chargingTime,
                    dischargingTime: battery.dischargingTime
                };
            })
            .catch(error => console.error(error));
    }
}

window.abs.usb = {
    connect: function (filters) {
        return navigator.usb.requestDevice({ filters: filters })
            .then(device => device.open())
            .then(device => device.selectConfiguration(1))
            .then(device => device.claimInterface(0))
            .catch(error => console.error(error));
    },
    disconnect: function (device) {
        return device.close()
            .catch(error => console.error(error));
    },
    readData: function (device, endpointNumber) {
        return device.transferIn(endpointNumber, 64)
            .then(result => new Uint8Array(result.data.buffer))
            .catch(error => console.error(error));
    },
}

window.abs.storage = {
    setItem: function (key, value) {
        localStorage.setItem(key, value);
    },
    getItem: function (key) {
        return localStorage.getItem(key);
    },
    removeItem: function (key) {
        localStorage.removeItem(key);
    }
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