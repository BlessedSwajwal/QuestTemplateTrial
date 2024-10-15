using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestTemplateTrial;
using QuestTemplateTrial.Model;

QuestPDF.Settings.License = LicenseType.Community;

var model = new D01Model()
{
    noOfExperience = 4
};
var document = new D01Document(model);
document.GeneratePdfAndShow();



var model2 = new D01Model()
{
    noOfExperience = 10
};
var document2 = new D01Document(model2);
document2.GeneratePdfAndShow();