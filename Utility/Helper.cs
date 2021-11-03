﻿using CRYBZ_CCSB.Models;
using CRYBZ_CCSB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Utility
{
    public static class Helper
    {
        
        public static readonly string Admin = "Beheerder";
        public static readonly string Employee = "Medewerker";
        public static readonly string Customer = "Klant";

        public static string AppointmentAdded = "Afspraak succesvol opgeslagen.";
        public static string AppointmentConfirmed = "Afspraak bevestigd.";
        public static string AppointmentUpdated = "Afspraak succesvol gewijzigd.";
        public static string AppointmentDeleted = "Afspraak succesvol verwijderd.";
        public static string AppointmentExists = "Afspraak bestaat al op gegeven datum en tijdstip.";
        public static string AppointmentNotExists = "Afspraak bestaat niet.";
        public static string AppointmentAddError = "Er ging iets mis. Afspraak niet toegevoegd.";
        public static string AppointmentConfirmError = "Er ging iets mis. Afspraak niet bevestigd.";
        public static string SomethingWentWrong = "Er ging iets mis. Probeer het opnieuw.";
        public static string AppointmentUpdatError = "Er ging iets mis. Afspraak niet gewijzigd.";

        public static string VehicleAdded = "Voertuig succesvol opgeslagen.";
        public static string VehicleConfirmed = "Voertuig bevestigd.";
        public static string VehicleUpdated = "Voertuig succesvol gewijzigd.";
        public static string VehicleDeleted = "Voertuig succesvol verwijderd.";
        public static string VehicleExists = "Voertuig bestaat al op.";
        public static string VehicleNotExists = "Voertuig bestaat niet.";
        public static string VehicleAddError = "Er ging iets mis. Voertuig niet toegevoegd.";
        public static string VehicleConfirmError = "Er ging iets mis. Voertuig niet bevestigd.";
        public static string VehicleUpdateError = "Er ging iets mis. Voertuig niet gewijzigd.";

        public static int Succes_code = 1;
        public static int Failure_code = 0;

        public static readonly string Caravan = "Caravan";
        public static readonly string Camper = "Camper";
        public static string EmailBody = (
            "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' style='width:100%;font-family:Arial, Helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'><head>    <meta charset='UTF-8'>    <meta content='width=device-width, initial-scale=1' name='viewport'>    <meta name='x-apple-disable-message-reformatting'>    <meta http-equiv='X-UA-Compatible' content='IE=edge'>    <meta content='telephone=no' name='format-detection'>    <title>CCSB Beheer</title>    <!--[if (mso 16)]>    <style type='text/css'>    a {text-decoration: none;}    </style>    <![endif]-->    <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]-->    <!--[if gte mso 9]>    <xml>    <o:OfficeDocumentSettings>    <o:AllowPNG></o:AllowPNG>    <o:PixelsPerInch>96</o:PixelsPerInch>    </o:OfficeDocumentSettings>    </xml>    <![endif]-->    <!--[if !mso]><!-- -->    <link href='https://fonts.googleapis.com/css?family=Lato:400,400i,700,700i' rel='stylesheet'>    <!--<![endif]-->    <style type='text/css'>        #outlook a {            padding: 0;        }        .ExternalClass {            width: 100%;        }            .ExternalClass,            .ExternalClass p,            .ExternalClass span,            .ExternalClass font,            .ExternalClass td,            .ExternalClass div {                line-height: 100%;            }        .es-button {            mso-style-priority: 100 !important;            text-decoration: none !important;            transition: all 100ms ease-in;        }        a[x-apple-data-detectors] {            color: inherit !important;            text-decoration: none !important;            font-size: inherit !important;            font-family: inherit !important;            font-weight: inherit !important;            line-height: inherit !important;        }        .es-button:hover {            background: #555555 !important;            border-color: #555555 !important;        }        .es-desk-hidden {            display: none;            float: left;            overflow: hidden;            width: 0;            max-height: 0;            line-height: 0;            mso-hide: all;        }        [data-ogsb] .es-button {            border-width: 0 !important;            padding: 15px 30px 15px 30px !important;        }            [data-ogsb] .es-button.es-button-1 {                padding: 15px 25px !important;            }        @media only screen and (max-width:600px) {            p, ul li, ol li, a {                line-height: 150% !important            }            h1, h2, h3, h1 a, h2 a, h3 a {                line-height: 120% !important            }            h1 {                font-size: 30px !important;                text-align: center            }            h2 {                font-size: 26px !important;                text-align: left            }            h3 {                font-size: 20px !important;                text-align: left            }            h1 a {                text-align: center            }            .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a {                font-size: 30px !important            }            h2 a {                text-align: left            }            .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a {                font-size: 20px !important            }            h3 a {                text-align: left            }            .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a {                font-size: 20px !important            }            .es-menu td a {                font-size: 16px !important            }            .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a {                font-size: 16px !important            }            .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a {                font-size: 17px !important            }            .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a {                font-size: 17px !important            }            .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a {                font-size: 12px !important            }            *[class='gmail-fix'] {                display: none !important            }            .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 {                text-align: center !important            }            .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 {                text-align: right !important            }            .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 {                text-align: left !important            }                .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img {                    display: inline !important                }            .es-button-border {                display: inline-block !important            }            a.es-button, button.es-button {                font-size: 14px !important;                display: inline-block !important;                border-width: 15px 25px 15px 25px !important            }            .es-btn-fw {                border-width: 10px 0px !important;                text-align: center !important            }            .es-adaptive table, .es-btn-fw, .es-btn-fw-brdr, .es-left, .es-right {                width: 100% !important            }            .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header {                width: 100% !important;                max-width: 600px !important            }            .es-adapt-td {                display: block !important;                width: 100% !important            }            .adapt-img {                width: 100% !important;                height: auto !important            }            .es-m-p0 {                padding: 0px !important            }            .es-m-p0r {                padding-right: 0px !important            }            .es-m-p0l {                padding-left: 0px !important            }            .es-m-p0t {                padding-top: 0px !important            }            .es-m-p0b {                padding-bottom: 0 !important            }            .es-m-p20b {                padding-bottom: 20px !important            }            .es-mobile-hidden, .es-hidden {                display: none !important            }            tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden {                width: auto !important;                overflow: visible !important;                float: none !important;                max-height: inherit !important;                line-height: inherit !important            }            tr.es-desk-hidden {                display: table-row !important            }            table.es-desk-hidden {                display: table !important            }            td.es-desk-menu-hidden {                display: table-cell !important            }            .es-menu td {                width: 1% !important            }            table.es-table-not-adapt, .esd-block-html table {                width: auto !important            }            table.es-social {                display: inline-block !important            }                table.es-social td {                    display: inline-block !important                }        }    </style></head><body style='width:100%;font-family:Arial, Helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'>    <div class='es-wrapper-color' style='background-color:#F1F1F1'>        <!--[if gte mso 9]>        <v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'>        <v:fill type='tile' color='#f1f1f1'></v:fill>        </v:background>        <![endif]-->        <table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top'>            <tr style='border-collapse:collapse'>                <td valign='top' style='padding:0;Margin:0'>                    <table cellpadding='0' cellspacing='0' class='es-header' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top'>                        <tr style='border-collapse:collapse'>                            <td align='center' style='padding:0;Margin:0'>                                <table class='es-header-body' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#ffffff;width:600px' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center'>                                    <tr style='border-collapse:collapse'>                                        <td style='Margin:0;padding-top:30px;padding-bottom:30px;padding-left:40px;padding-right:40px;background-color:#fefafa' bgcolor='#fefafa' align='left'>                                            <table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                <tr style='border-collapse:collapse'>                                                    <td valign='top' align='center' style='padding:0;Margin:0;width:520px'>                                                        <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;font-size:0px'><a href='https://viewstripo.email/' target='_blank' style='-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#FFFFFF;font-size:14px'><img src='https://i.ibb.co/2jSV2kr/CCSB-Logo.png' alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' height='100'></a></td>                                                            </tr>                                                        </table>                                                    </td>                                                </tr>                                            </table>                                        </td>                                    </tr>                                </table>                            </td>                        </tr>                    </table>                    <table class='es-content' cellspacing='0' cellpadding='0' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'>                        <tr style='border-collapse:collapse'>                            <td align='center' style='padding:0;Margin:0'>                                <table class='es-content-body' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#37d400;width:600px' cellspacing='0' cellpadding='0' bgcolor='#333333' align='center'>                                    <tr style='border-collapse:collapse'>                                        <td style='Margin:0;padding-top:40px;padding-bottom:40px;padding-left:40px;padding-right:40px;background-image:url();background-repeat:no-repeat;background-position:left top' align='left' background=''>                                            <table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                <tr style='border-collapse:collapse'>                                                    <td valign='top' align='center' style='padding:0;Margin:0;width:520px'>                                                        <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;padding-bottom:10px;padding-top:40px;color:white;'><h1 style='Margin:0;line-height:36px;mso-line-height-rule:exactly;font-family:lato,; color:white; 'helvetica neue', helvetica, arial, sans-serif;font-size:30px;font-style:normal;font-weight:bold;color:white;'>Welkom @@FirstName!</h1></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td esdev-links-color='#757575' align='center' style='Margin:0;padding-top:10px;padding-bottom:20px;padding-left:30px;padding-right:30px; color:white;'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica,; color:white 'helvetica neue', arial, verdana, sans-serif;line-height:23px;color:#474747;font-size:15px'>Bedankt voor je aanmelding bij CCSB!<br>Wij zijn CCSB en wij nemen je camper mee!<br>Of caravan natuurlijk.</p></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;padding-top:10px;padding-bottom:20px'><span class='es-button-border' style='border-style:solid;border-color:#ffffff;background:#ffffff;border-width:0px;display:inline-block;border-radius:50px;width:auto'><a href='https://localhost:44310/Account/Login' class='es-button' target='_blank' style='mso-style-priority:100 !important;text-decoration:none;transition:all 100ms ease-in;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#37d400;font-size:14px;border-style:solid;border-color:#ffffff;border-width:15px 30px 15px 30px;display:inline-block;background:#ffffff;border-radius:50px;font-family:Arial, Helvetica, sans-serif;font-weight:bold;font-style:normal;line-height:17px;width:auto;text-align:center'>INLOGGEN</a></span></td>                                                            </tr>                                                        </table>                                                    </td>                                                </tr>                                            </table>                                        </td>                                    </tr>                                </table>                            </td>                        </tr>                    </table>                    <table class='es-content' cellspacing='0' cellpadding='0' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'>                        <tr style='border-collapse:collapse'>                            <td align='center' style='padding:0;Margin:0'>                                <table class='es-content-body' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px'>                                    <tr style='border-collapse:collapse'>                                        <td align='left' style='padding:0;Margin:0;padding-top:40px;padding-left:40px;padding-right:40px'>                                            <table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                <tr style='border-collapse:collapse'>                                                    <td valign='top' align='center' style='padding:0;Margin:0;width:520px'>                                                        <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                            <tr style='border-collapse:collapse'>                                                                <td class='es-m-txt-c' align='left' style='padding:0;Margin:0;padding-top:5px;padding-bottom:15px'><h2 style='Margin:0;line-height:24px;mso-line-height-rule:exactly;font-family:lato, 'helvetica neue', helvetica, arial, sans-serif;font-size:20px;font-style:normal;font-weight:bold;color:#333333'>JE ACCOUNT IS NU ACTIEF</h2></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='left' style='padding:0;Margin:0;padding-bottom:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:23px;color:#555555;font-size:15px'>Je account is nu officieel actief en dat betekend dat je vanaf nu in kunt loggen en kan reserveren binnen ons systeem. Hieronder staan je unieke inloggegevens die je kunt gebruiken om in te loggen.</p></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='left' style='padding:0;Margin:0;padding-top:10px;padding-bottom:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:23px;color:#555555;font-size:15px'><strong>Gebruikersnaam:</strong> @@Email<br><strong>Wachtwoord: </strong>@@Password</p></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='left' style='padding:0;Margin:0;padding-top:10px;padding-bottom:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:23px;color:#555555;font-size:15px'>Met vriendelijke groet,</p></td>                                                            </tr>                                                        </table>                                                    </td>                                                </tr>                                            </table>                                        </td>                                    </tr>                                    <tr style='border-collapse:collapse'>                                        <td align='left' style='Margin:0;padding-top:10px;padding-bottom:40px;padding-left:40px;padding-right:40px'>                                            <!--[if mso]><table style='width:520px' cellpadding='0'                                            cellspacing='0'><tr><td style='width:40px' valign='top'><![endif]-->                                            <table class='es-left' cellspacing='0' cellpadding='0' align='left' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left'>                                                <tr style='border-collapse:collapse'>                                                    <td class='es-m-p0r es-m-p20b' valign='top' align='center' style='padding:0;Margin:0;width:40px'>                                                        <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;font-size:0px'><img src='https://i.ibb.co/rb5L2yJ/nice3.png' alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' width='40'></td>                                                            </tr>                                                        </table>                                                    </td>                                                </tr>                                            </table>                                            <!--[if mso]></td><td style='width:20px'></td><td style='width:460px' valign='top'><![endif]-->                                            <table cellspacing='0' cellpadding='0' align='right' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                <tr style='border-collapse:collapse'>                                                    <td align='left' style='padding:0;Margin:0;width:460px'>                                                        <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                            <tr style='border-collapse:collapse'>                                                                <td align='left' style='padding:0;Margin:0;padding-top:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:21px;color:#222222;font-size:14px'><b>Sophia</b></p></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='left' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:21px;color:#666666;font-size:14px'>BEHEER | CCSB</p></td>                                                            </tr>                                                        </table>                                                    </td>                                                </tr>                                            </table>                                            <!--[if mso]></td></tr></table><![endif]-->                                        </td>                                    </tr>                                </table>                            </td>                        </tr>                    </table>                    <table class='es-content' cellspacing='0' cellpadding='0' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'>                        <tr style='border-collapse:collapse'>                            <td align='center' style='padding:0;Margin:0'>                                <table class='es-content-body' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#26a4d3;width:600px' cellspacing='0' cellpadding='0' bgcolor='#26a4d3' align='center'>                                    <tr style='border-collapse:collapse'>                                        <td style='Margin:0;padding-bottom:20px;padding-top:40px;padding-left:40px;padding-right:40px;background-color:#37d400' bgcolor='#37d400' align='left'>                                            <table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                <tr style='border-collapse:collapse'>                                                    <td valign='top' align='center' style='padding:0;Margin:0;width:520px'>                                                        <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                            <tr style='border-collapse:collapse'>                                                                <td color:#FFFFFF; class='es-m-txt-c' align='center' style='padding:0;Margin:0'><h2 style='Margin:0;line-height:24px;mso-line-height-rule:exactly;font-family:Arial, Helvetica, sans-serif;color:white;'>VOOR VERDERE VRAGEN</h2></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;padding-top:5px;padding-bottom:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica; color:white; 'helvetica neue', arial, verdana, sans-serif;line-height:26px;color:#ffffff;font-size:17px'>Zijn wij altijd te bereiken via het onderstaande adres.</p></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;padding-top:10px;padding-bottom:20px'><span class='es-button-border' style='border-style:solid;border-color:#ffffff;background:#ffffff;border-width:0px;display:inline-block;border-radius:50px;width:auto'><a href='mailto:beheervanccsb@gmail.com' class='es-button' target='_blank' style='mso-style-priority:100 !important;text-decoration:none;transition:all 100ms ease-in;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#37d400;font-size:14px;border-style:solid;border-color:#ffffff;border-width:15px 30px 15px 30px;display:inline-block;background:#ffffff;border-radius:50px;font-family:Arial, Helvetica, sans-serif;font-weight:bold;font-style:normal;line-height:17px;width:auto;text-align:center'>MAIL ONS</a></span></td>                                                            </tr>                                                        </table>                                                    </td>                                                </tr>                                            </table>                                        </td>                                    </tr>                                </table>                            </td>                        </tr>                    </table>                    <table cellpadding='0' cellspacing='0' class='es-footer' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top'>                        <tr style='border-collapse:collapse'>                            <td align='center' style='padding:0;Margin:0'>                                <table class='es-footer-body' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#ffffff;width:600px' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center'>                                    <tr style='border-collapse:collapse'>                                        <td align='left' style='Margin:0;padding-top:40px;padding-bottom:40px;padding-left:40px;padding-right:40px'>                                            <table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                <tr style='border-collapse:collapse'>                                                    <td valign='top' align='center' style='padding:0;Margin:0;width:520px'>                                                        <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;padding-bottom:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:18px;color:#666666;font-size:12px'>CCSB 2021</p></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0;padding-bottom:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:18px;color:#666666;font-size:12px'>Deze email is verstuurd vanuit het CCSB hoofdkwartier</p></td>                                                            </tr>                                                            <tr style='border-collapse:collapse'>                                                                <td align='center' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:helvetica, 'helvetica neue', arial, verdana, sans-serif;line-height:18px;color:#666666;font-size:12px'>Copyright © 2015-2021&nbsp;<b>CCSB</b>, All Rights Reserved.</p></td>                                                            </tr>                                                        </table>                                                    </td>                                                </tr>                                            </table>                                        </td>                                    </tr>                                </table>                            </td>                        </tr>                    </table>                </td>            </tr>        </table>    </div></body></html>");
        
        
        
        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{ Value=Helper.Admin , Text = Helper.Admin},
                new SelectListItem{ Value=Helper.Employee , Text = Helper.Employee},
                new SelectListItem{ Value=Helper.Customer , Text = Helper.Customer}
            };
            return items.OrderBy(s => s.Text).ToList();
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 10; i < 90; i += 10)
            {
                duration.Add(new SelectListItem { Value = i.ToString(), Text = i + " minuten" });
            }
            return duration;
        }
        public static List<SelectListItem> GetVehicleType()
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{ Value=Helper.Caravan , Text = Helper.Caravan},
                new SelectListItem{ Value=Helper.Camper , Text = Helper.Camper}
            };
            return items.OrderBy(s => s.Text).ToList();
        }
        
    }
}