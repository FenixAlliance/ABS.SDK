window.abs = {
    share: function (data) {
        navigator.share(data)
    },
    getIp: function () {
        return ip;
    },
    getCartID: function () {
        return CartID;
    },
    setLayout: function (ref) {
        window.layout = ref;
    },
    setCommandBar: function (ref) {
        window.commandBar = ref;
    },
    formatAmount: function (amount, currency = "USD", locale = "en-US", style = "currency", currencyDisplay = "symbol", minimumFractionDigits = 2) {
        return new Intl.NumberFormat(locale, { style: style, currency: currency.split('.')[0], currencyDisplay: currencyDisplay, minimumFractionDigits: minimumFractionDigits }).format(amount)
    },
    formatCurrency: function (number, currency = "USD", locale = "en-US") {
        return new Intl.NumberFormat(locale, { style: 'currency', currency: currency }).format(number)
    },
    exchangeRate: function (amount, from, to) {
        return fx(amount).from(from.split('.')[0]).to(to.split('.')[0]);
    },
    openUrl: function (url, target = "_blank") {
        window.open(url, target);
    },
    openUrlNewTab: function (url) {
        window.open(url, "_blank");
    },
    injectScript: function (source) {
        $('<script />', { type: 'text/javascript', src: source }).appendTo('head');
    },
    addScript: function (url)  {
        $(document).ready(function () {
            $.getScript(url);
        });
    },
    writeCookie: function (name, value, days = 365) {
        var expires;
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toGMTString();
        }
        else {
            expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    },
    readCookie: function (cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    },
    setImage: async function (imageElementId, imageStream) {
        const arrayBuffer = await imageStream.arrayBuffer();
        const blob = new Blob([arrayBuffer]);
        const url = URL.createObjectURL(blob);
        document.getElementById(imageElementId).src = url;
        URL.revokeObjectURL(url);
    },
    selectLang: function (culture) {
        value = "c=" + culture + "|uic=" + culture;
        Cookies.set('.AspNetCore.Culture', value);
        window.location.reload();
    },
    notification: function (notificationType, notificationMessage) {
        // Display an info toast with no title
        switch (notificationType) {
            case "info":
            case "Info":
                toastr.info(notificationMessage);
                break;
            case "Success":
            case "success":
                toastr.success(notificationMessage);
                break;
            case "Warning":
            case "warning":
                toastr.warning(notificationMessage);
                break;
            case "Error":
            case "error":
                toastr.error(notificationMessage);
                break;
        }
    },
    toastNotification: function (notificationType, notificationMessage) {
        window.abs.notification(notificationType, notificationMessage);
    },
    toastrNotification: function (notificationType, notificationMessage) {
        window.abs.notification(notificationType, notificationMessage);
    },
    toggleTheme: function () {
        if ($("body").hasClass('theme-dark')) {
            $("body").removeClass('theme-dark');
        } else {
            $("body").addClass('theme-dark');
        }
    },
    addBodyClass: function (newClass) {
        $('body').addClass(newClass);
    },
    removeBodyClass: function (newClass) {
        $('body').removeClass(newClass);
    },
    initPhoneInput: function (options) {
        try {
            
            var input = document.querySelector(".phone");
            window.intlTelInput(input, options);

        } catch (e) {

        }
    },
    openHoldOn: function (text = "Loading...", bgColor = "#ffffff", textColor = "white") {

        var options = {
            theme: "sk-cube-grid",
            message: text,
            backgroundColor: bgColor,
            textColor: textColor
        };

        HoldOn.open(options);
    },
    closeHoldOn: function () {
        HoldOn.close();
    },
    finishLoading: function () {
        HoldOn.close();
        NProgress.done()
    },
    startLoading: function (text = "Loading...", bgColor = "#ffffff", textColor = "white") {

        var options = {
            theme: "sk-cube-grid",
            message: text,
            backgroundColor: bgColor,
            textColor: textColor
        };

        HoldOn.open(options);
        NProgress.start()
    },
    setExchangeRates: function (rates) {
        // Check money.js has finished loading:
        if (typeof fx !== "undefined" && fx.rates) {
            fx.rates = rates.rates;
            fx.base = rates.base;
        } else {
            // If not, apply to fxSetup global:
            var fxSetup = {
                rates: rates.rates,
                base: rates.base
            }
        }
    },
    initForexRates: function () {
        var path = "https://raw.githubusercontent.com/ComputeWorks/Forex/main/latest.json";
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    abs.setExchangeRates(JSON.parse(xhr.responseText));
                }
                else {
                    console.error(xhr);
                }
            }
        };
        xhr.open('GET', path, true);
        xhr.send();
    }
};