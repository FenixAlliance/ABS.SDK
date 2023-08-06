using FenixAlliance.ABS.SDK.Constants;
using FenixAlliance.ABS.SDK.Models.Interop;

using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FenixAlliance.ABS.SDK.Extensions
{
	public enum NotificationType
	{
		Info,
		Error,
		Success,
		Warning,
	}
	public static class InteropExtensions
	{

		public static async Task<string> GetIp(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.GetIp);
		}

		public static async Task<string> GetCartID(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.GetCartID);
		}

		public static async Task<string> StartLoading(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.StartLoading);
		}

		public static async Task<string> InitPhoneInput(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.InitPhoneInput);
		}

		public static async Task<string> FinishLoading(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.FinishLoading);
		}

		public static async Task<string> InitForexRates(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.InitForexRates);
		}

		public static async Task<string> FormatAmount(this IJSRuntime js, double amount, string currency = "USD", string locale = "en-US", string style = "currency", string currencyDisplay = "symbol", int minimumFractionDigits = 2)
		{
			return await js.InvokeAsync<string>(InteropMethods.FormatAmount, amount, currency, locale, style, currencyDisplay, minimumFractionDigits);
		}

		public static async Task<string> FormatCurrency(this IJSRuntime js, double amount, string currency = "USD", string locale = "en-US")
		{
			return await js.InvokeAsync<string>(InteropMethods.FormatCurrency, amount, currency, locale);
		}

		public static async Task<T> ExchangeAmount<T>(this IJSRuntime js, T amount, string from, string to)
		{
			return await js.InvokeAsync<T>(InteropMethods.ExchangeAmount, amount, from, to);
		}

		public static async Task<string> Notification(this IJSRuntime js, string type, string message)
		{
			return await js.InvokeAsync<string>(InteropMethods.Notification, type, message);
		}

		public static async Task Notification(this IJSRuntime js, NotificationType type, string message)
		{
			// use switch case for each notification type
			switch (type)
			{
			case NotificationType.Info:
			await js.Notification("info", message);
			break;
			case NotificationType.Error:
			await js.Notification("error", message);
			break;
			case NotificationType.Success:
			await js.Notification("success", message);
			break;

			case NotificationType.Warning:
			await js.Notification("warning", message);
			break;
			default:
			throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}

		public static async Task SuccessNotification(this IJSRuntime js, string message)
		{
			await js.Notification(NotificationType.Success, message);
		}

		public static async Task WarningNotification(this IJSRuntime js, string message)
		{
			await js.Notification(NotificationType.Warning, message);
		}

		public static async Task ErrorNotification(this IJSRuntime js, string message)
		{
			await js.Notification(NotificationType.Error, message);
		}

		public static async Task InfoNotification(this IJSRuntime js, string message)
		{
			await js.Notification(NotificationType.Info, message);
		}


		#region DOM
		public static async Task ToggleTheme(this IJSRuntime js, string cname)
		{
			await js.InvokeVoidAsync(InteropMethods.ToggleTheme, cname);
		}
		public static async Task AddBodyClass(this IJSRuntime js, string cname)
		{
			await js.InvokeVoidAsync(InteropMethods.AddBodyClass, cname);
		}

		public static async Task RemoveBodyClass(this IJSRuntime js, string cname)
		{
			await js.InvokeVoidAsync(InteropMethods.RemoveBodyClass, cname);
		}

		public static async Task InjectScript(this IJSRuntime js, string url)
		{
			await js.InvokeVoidAsync(InteropMethods.InjectScript, url);
		}

		public static async Task OpenUrl(this IJSRuntime js, string url, string target = "_blank")
		{
			await js.InvokeVoidAsync(InteropMethods.OpenUrl, url, target);
		}

		public static async Task OpenUrlNewTab(this IJSRuntime js, string url)
		{
			await js.InvokeVoidAsync(InteropMethods.OpenUrlNewTab, url);
		}
		public static async Task SelectLang(this IJSRuntime js, string culture)
		{
			await js.InvokeVoidAsync(InteropMethods.SelectLang, culture);
		}
		public static async Task PlayAudio(this IJSRuntime js, string elementId)
		{
			await js.InvokeVoidAsync(InteropMethods.PlayAudio, elementId);
		}
		public static async Task PlayNotificationSound(this IJSRuntime js)
		{
			await js.PlayAudio("notification");
		}
		#endregion



		#region Geolocation
		public static async Task<string> GetLatitude(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.GetLatitude);
		}


		public static async Task<string> GetLongitude(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.GetLongitude);
		}

		public static async Task GetCurrentPosition(this IJSRuntime js)
		{
			await js.InvokeVoidAsync(InteropMethods.GetCurrentPosition);
		}
		#endregion


		#region Cookies
		public static async Task<string> ReadCookie(this IJSRuntime js, string name)
		{
			return await js.InvokeAsync<string>(InteropMethods.ReadCookie);
		}
		public static async void WriteCookie(this IJSRuntime js, string name, string value, int days)
		{
			await js.InvokeVoidAsync(InteropMethods.WriteCookie, name, value, days);
		}
		#endregion


		#region Connection

		public static async Task<string> GetConnectionType(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.GetConnectionType);
		}

		public static async Task<string> DetectConnectionChanges(this IJSRuntime js)
		{
			return await js.InvokeAsync<string>(InteropMethods.DetectConnectionChanges);
		}
		#endregion

		#region Payment
		public static async void PaymentRequest(this IJSRuntime js, IEnumerable<SupportedInstruments> supportedInstruments, PaymentDetails paymentDetails)
		{
			await js.InvokeVoidAsync(InteropMethods.Pay, supportedInstruments, paymentDetails);
		}

		#endregion

		#region Share
		public static async void Share(this IJSRuntime js, ShareData shareData)
		{
			await js.InvokeVoidAsync(InteropMethods.Share, shareData);
		}
		#endregion

	}
}
