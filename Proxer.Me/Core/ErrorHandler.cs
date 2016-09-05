using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxer.Me.ProxSupport;
using Proxer.Me.ViewModels;
using Proxer.Me.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Core
{
	public static class ErrorHandler
	{
		private static bool showsError = false;

		public static async void ShowError(int Code)
		{
			LoginViewModel.Instance.Model.UserLoggedIn = false;
			if (!showsError)
			{
				showsError = true;
				var errorContent = getErrorContent(Code);
				var errorTitle = getErrorTitle(Code);
				var dialog = new Windows.UI.Popups.MessageDialog(errorContent, errorTitle);

				if (Code == (int)Codes.ServerUnavailable)
				{
					dialog.Content += " [DDOS-Schutz ist möglicherweis an]";
				}
				dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
				if (Code == (int)Codes.IPBlocked)
				{
					dialog.Commands.Add(new Windows.UI.Popups.UICommand("Captcha") { Id = 1 });
				}

				dialog.CancelCommandIndex = 0;
				if (Code == (int)Codes.IPBlocked)
				{
					dialog.DefaultCommandIndex = 1;
				}
				else
				{
					dialog.DefaultCommandIndex = 0;
				}

				var result = await dialog.ShowAsync();
				showsError = false;
				//if (Code == (int)Codes.ServerUnavailable)
				//{
				//	Windows.UI.Xaml.Application.Current.Exit();
				//}
				if ((int)result.Id == 1)
				{
					if (Code == (int)Codes.IPBlocked)
					{
						var frame = Window.Current.Content as Frame;
						if (frame.CurrentSourcePageType == typeof(LoginPage))
							frame.Navigate(typeof(CaptchaCleanPage), null);
						else
							frame.Navigate(typeof(CaptchaPage), null);
					}
				}
			}
		}

		private static string getErrorTitle(int code)
		{
			Codes _code;
			string title = $"({code}) ";
			if (Enum.TryParse(code.ToString(), out _code))
			{
				switch (_code)
				{
					case Codes.BadRequest:
						title += "Bad Request";
						break;

					case Codes.Unauthorized:
						title += "Unauthorized";
						break;

					case Codes.Forbidden:
						title += "Forbidden";
						break;

					case Codes.NotFound:
						title += "Not Found";
						break;

					case Codes.InternalServerError:
						title += "Internal Server Error";
						break;

					case Codes.NotImplemented:
						title += "Not Implemented";
						break;

					case Codes.BadGateway:
						title += "Bad Gateway";
						break;

					case Codes.ServerUnavailable:
						title += "Service Unavailable";
						break;

					case Codes.GatewayTimeOut:
						title += "Gateway Time-out";
						break;

					case Codes.HTTPVersionNotSupported:
						title += "HTTP Version not supported";
						break;

					case Codes.NotExtended:
						title += "Not Extended";
						break;

					case Codes.AuthentificationRequired:
						title += "Network Authentication Required";
						break;

					case Codes.APIVersionNotFound:
						title += "ProxerAPI Version nicht gefunden";
						break;

					case Codes.APIVersionDeleted:
						title += "ProxerAPI Version existiert nicht mehr";
						break;

					case Codes.APIClassNotFound:
						title += "ProxerAPI Klasse nicht gefunden";
						break;

					case Codes.APIFunctionNotFound:
						title += "ProxerAPI Funktion nicht gefunden";
						break;

					case Codes.APIKeyAccessLevelToLow:
						title += "API Key Level to low";
						break;

					case Codes.ExpiredToken:
						title += "Token abgelaufen";
						break;

					case Codes.FunktionLocked:
						title += "Funtion gesperrt";
						break;

					case Codes.IPBlocked:
						title += "IP Blocked";
						break;

					case Codes.NewsError:
						title += "News Error";
						break;

					case Codes.LoginDataMissing:
						title += "Login-Daten fehlen";
						break;

					case Codes.LoginDataWrong:
						title += "Login-Daten falsch";
						break;

					case Codes.UserNotLoggedIn_Notification:
						title += "User nicht eingeloggt [Notifications]";
						break;

					case Codes.UnknownUser:
						title += "Unbekannter Nutzer [UCP]";
						break;

					case Codes.UserNotLoggedIn_UCP:
						title += "User nicht eingeloggt [UCP]";
						break;

					case Codes.CategoryNotFound_UCP:
						title += "Unbekannte Kategorie [UCP]";
						break;

					case Codes.UnknownID_UCP:
						title += "Unbekannte ID [UCP]";
						break;

					case Codes.UnknownID_Info:
						title += "Unbekannte ID [Info]";
						break;

					case Codes.WrongType:
						title += "Ungültiger Typ [Info]";
						break;

					case Codes.UserNotLoggedIn_Info:
						title += "User nicht eingeloggt [Info]";
						break;

					case Codes.EntryAlreadyInList:
						title += "Werk bereits in der Liste enhalten [Info]";
						break;

					case Codes.MaximumAmountOfFavs:
						title += "Anzahl an zulässigen Favoriten überschritten [Info]";
						break;

					case Codes.UserAlreadyLoggedIn:
						title += "User bereits eingeloggt";
						break;

					case Codes.DiffrentUserAlreadyLoggedIn:
						title += "Ein anderer User ist bereits eingeloggt";
						break;

					case Codes.AccessDenied:
						title += "Zugriff verweigert";
						break;

					case Codes.CategoryNotFound_List:
						title += "Kategorie nicht gefunden [List]";
						break;

					case Codes.MediumNotFound:
						title += "Medium existiert nicht [List]";
						break;

					case Codes.StyleNotFound:
						title += "Style nicht gefunden [Media]";
						break;

					case Codes.EntryNotFound:
						title += "Eintrag existiert nicht [Media]";
						break;

					case Codes.ChapterNotUploaded:
						title += "Kapitel existiert nicht (nicht hochgeladen)";
						break;

					case Codes.EpisodeNotUploaded:
						title += "Episode exisitert nicht (keine Streams)";
						break;

					case Codes.StreamNotFound:
						title += "Stream existiert nicht";
						break;

					case Codes.EpisodeNotFound:
						title += "Episode existiert nicht [UCP]";
						break;

					case Codes.UserNotLoggedIn_Messenger:
						title += "User nicht eingeloggt [Messenger]";
						break;

					case Codes.UnknownID_Messenger:
						title += "Ungültige Konferenz (fehlende Berechtigung oder fehlerhafte Konferenz-ID)";
						break;

					case Codes.UnknownReason_Messenger:
						title += "Ungültige/Fehlende Eingabe bei Meldegrund";
						break;

					case Codes.UnknownMessage_Messenger:
						title += "Ungültige/Fehlende Nachricht";
						break;

					case Codes.UnknownReciever:
						title += "Ungültiger Empfänger";
						break;

					case Codes.MaxAmountOfUserReached:
						title += "Die maximale Anzahl an Usern wurde erreicht";
						break;

					case Codes.UnknownSubject:
						title += "Ungültiges/Fehlendes Thema";
						break;

					case Codes.NotEnoughUser:
						title += "Es muss mindestens ein Benutzer in einer Konferenz hinzugefügt werden";
						break;
				}
			}
			else
			{
				title += "Unknown Error";
			}
			return title;
		}

		private static string getErrorContent(int code)
		{
			Codes _code;
			string content = "";
			if (Enum.TryParse(code.ToString(), out _code))
			{
				switch (_code)
				{
					case Codes.BadRequest:
					case Codes.Unauthorized:
					case Codes.Forbidden:
					case Codes.NotFound:
						content += "Scheint als versuche die App etwas zu machen, was sie laut API nicht darf.";
						break;

					case Codes.InternalServerError:
					case Codes.NotImplemented:
					case Codes.BadGateway:
					case Codes.ServerUnavailable:
					case Codes.GatewayTimeOut:
					case Codes.HTTPVersionNotSupported:
					case Codes.NotExtended:
					case Codes.AuthentificationRequired:
						content += "Scheint als will der Proxer Server nicht antworten, bitte versuche es später erneut.";
						break;

					case Codes.APIVersionNotFound:
						content += "Die genutzte API existiert nicht.";
						break;

					case Codes.APIVersionDeleted:
						content += "Die API Version existiert nicht mehr.";
						break;

					case Codes.APIClassNotFound:
						content += "Die API Klasse existiert nicht.";
						break;

					case Codes.APIFunctionNotFound:
						content += "Die API Funktion existiert nicht.";
						break;

					case Codes.APIKeyAccessLevelToLow:
						content += "Diese App darf nicht auf diesen Bereich zugreifen.";
						break;

					case Codes.ExpiredToken:
						content += "Der User Token ist abgelaufen. Bitte log dich aus und wieder ein.";
						break;

					case Codes.FunktionLocked:
						content += "Diese Funktion wurde in der API gesperrt.";
						break;

					case Codes.IPBlocked:
						content += "gg Proxer hält dich für einen Bot und hat deine IP gesperrt.";
						break;

					case Codes.NewsError:
						content += "Fehler beim abfragen der News.";
						break;

					case Codes.LoginDataMissing:
						content += "Die Login-Daten scheinen nicht übertragen worden zu sein.";
						break;

					case Codes.LoginDataWrong:
						content += "Die angegebenen Login-Daten sind falsch.";
						break;

					case Codes.UserNotLoggedIn_Notification:
					case Codes.UserNotLoggedIn_UCP:
					case Codes.UserNotLoggedIn_Info:
					case Codes.UserNotLoggedIn_Messenger:
						content += "Kein User eingeloggt.";
						break;

					case Codes.UnknownUser:
					case Codes.UnknownID_UCP:
					case Codes.UnknownID_Info:
						content += "Dieses UserID oder dieser Username ist unbekannt.";
						break;

					case Codes.CategoryNotFound_UCP:
					case Codes.CategoryNotFound_List:
						content += "Die übermittelte Kategorie ist unbekannt.";
						break;

					case Codes.WrongType:
						content += "Der übermittelte Typ ist unbekannt.";
						break;

					case Codes.EntryAlreadyInList:
						content += "Dieses Werk befindet sich bereits in deiner Liste.";
						break;

					case Codes.MaximumAmountOfFavs:
						content += "Maximal Anzahl an Favoriten überschritten.";
						break;

					case Codes.UserAlreadyLoggedIn:
						content += "Du bist bereits eingeloggt.";
						break;

					case Codes.DiffrentUserAlreadyLoggedIn:
						content += "Aktuell ist bereits ein anderer User eingeloggt.";
						break;

					case Codes.AccessDenied:
						content += "Zugriff verweigert [Bist du eingeloggt?]";
						break;

					case Codes.MediumNotFound:
						content += "Das übermittelte Medium ist unbekannt.";
						break;

					case Codes.StyleNotFound:
						content += "Der übermittelte Style ist unbekannt.";
						break;

					case Codes.EntryNotFound:
						content += "Die übermittelte ID ist unbekannt.";
						break;

					case Codes.ChapterNotUploaded:
						content += "Dieses Kapitel existiert nicht oder scheint noch nicht hochgeladen zu sein.";
						break;

					case Codes.EpisodeNotUploaded:
						content += "Diese Episode existiert nicht oder scheint noch nicht hochgeladen zu sein.";
						break;

					case Codes.StreamNotFound:
						content += "Der Stream Provider ist unbekannt.";
						break;

					case Codes.EpisodeNotFound:
						content += "Diese Episode existiert nicht.";
						break;

					case Codes.UnknownID_Messenger:
						content += "Diese Konferenz existiert nicht oder du hast keine Berechtigung für diese.";
						break;

					case Codes.UnknownReason_Messenger:
						content += "Der Meldegrund ist entweder leer oder enthält Zeichen, die Proxer nicht mag.";
						break;

					case Codes.UnknownMessage_Messenger:
						content += "Die Nachricht ist entweder leer oder enthält Zeichen, die Proxer nicht mag.";
						break;

					case Codes.UnknownReciever:
						content += "Der Empfänger sagt Proxer nichts.";
						break;

					case Codes.MaxAmountOfUserReached:
						content += "Rien ne va plus. (max. User erreicht)";
						break;

					case Codes.UnknownSubject:
						content += "Das Thema ist entweder leer oder enthält Zeichen, die Proxer nicht mag.";
						break;

					case Codes.NotEnoughUser:
						content += "Wem soll das ganze denn zugeschickt werden? (Benutzer fehlen)";
						break;
				}
			}
			else
			{
				content += "Unbekannter Fehler";
			}
			return content;
		}
	}
}