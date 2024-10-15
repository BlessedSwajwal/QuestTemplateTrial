using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestTemplateTrial;
using QuestTemplateTrial.Model;

QuestPDF.Settings.License = LicenseType.Community;

var model = new D01Model();
var document = new D01Document(model);
document.GeneratePdfAndShow();