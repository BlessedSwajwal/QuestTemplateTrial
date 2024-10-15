using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestTemplateTrial.Model;

namespace QuestTemplateTrial;
internal class D01Document : IDocument
{
    public D01Model Model { get; }

    public D01Document(D01Model model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(0);

                page.Content().Element(ComposeContent);
            });
    }

    void ComposeContent(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem(2)
            .Background(Color.FromHex("323b4c"))
            .Padding(10)
            .Column(handler => ComposeSidebar(handler));

            row
            .RelativeItem(5)
            .PaddingTop(50)
            .PaddingHorizontal(20)
            .Background(Colors.White)
            .Column(handler => ComposeMain(handler));
        });
    }

    void ComposeSidebar(ColumnDescriptor col)
    {
        //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        //// Combine it with the relative path to the image
        //string imagePath = Path.Combine(baseDirectory, "avatar-modified.png");
        //col.Item().AlignCenter().Width(100).Image(imagePath);

        col.Item().AlignCenter().Width(100).Height(100).Placeholder();

        ComposeSidebarHeader(col, "Contact");

        col.Item().PaddingTop(20).PaddingLeft(30).ShowEntire().Row(row => row.RelativeItem().Column(col =>
        {
            col.Item().Text("Phone").Bold().FontColor(Colors.White).FontSize(14);
            col.Item().Text("9865206734").FontColor(Colors.White).FontSize(12);
        }));

        col.Item().PaddingTop(20).PaddingLeft(30).ShowEntire().Row(row => row.RelativeItem().Column(col =>
        {
            col.Item().Text("Email").Bold().FontColor(Colors.White).FontSize(14);
            col.Item().Text("nospamsajal@gmail.com").FontColor(Colors.White).FontSize(12);
        }));

        col.Item().PaddingTop(20).PaddingLeft(30).ShowEntire().Row(row => row.RelativeItem().Column(col =>
        {
            col.Item().Text("Address").Bold().FontColor(Colors.White).FontSize(14);
            col.Item().Text("Bhaktapur, Nepal").FontColor(Colors.White).FontSize(12);
        }));

        ComposeSidebarHeader(col, "Education");
        ComposeExperienceDetail(col, "2008", "Degree in Computer Science", "NASS");
        ComposeExperienceDetail(col, "2008", "Degree in Computer Science", "NASS");
        ComposeExperienceDetail(col, "2008", "Degree in Computer Science", "NASS");


        ComposeSidebarHeader(col, "Expertise");

        var skillTextStyle = TextStyle.Default.FontColor(Colors.White).FontSize(12);

        col.Item().PaddingTop(5).AlignCenter().Text("Html").Style(skillTextStyle);
        col.Item().PaddingTop(5).AlignCenter().Text("Css").Style(skillTextStyle);
        col.Item().PaddingTop(5).AlignCenter().Text("Javascript").Style(skillTextStyle);
        col.Item().PaddingTop(5).AlignCenter().Text("C#").Style(skillTextStyle);
    }

    void ComposeSidebarHeader(ColumnDescriptor col, string header)
    {
        col.Item().PaddingTop(20).Text(header).Bold().FontColor(Colors.White).FontSize(20).AlignCenter();
        col.Item().PaddingTop(10).PaddingLeft(40).LineHorizontal(1).LineColor(Colors.White);
    }

    void ComposeExperienceDetail(ColumnDescriptor col, string year, string expTitle, string uni)
    {
        col.Item().PaddingTop(20).PaddingLeft(30).ShowEntire().Row(row => row.RelativeItem().Column(col =>
        {
            col.Item().Text(year).Bold().FontColor(Colors.White).FontSize(14);
            col.Item().Text(expTitle).FontColor(Colors.White).FontSize(12);
            col.Item().Text(uni).FontColor(Colors.White).FontSize(12);
        }));
    }

    void ComposeMain(ColumnDescriptor col)
    {
        col.Item().Text(text =>
        {
            text.Span("Sajal").ExtraBlack().FontColor(Colors.Black).FontSize(30);
            text.Span(" Ghimire").Light().FontColor(Colors.Black).FontSize(30);
        });

        col.Item().Text(".NET Developer")
            .Light()
            .LetterSpacing(0.4f);

        col.Item().PaddingTop(5).Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit, Nullam pharetra in lorem at laoreet. Donec hendrerit libero eget est tempor, quis tempus arcu elementum. In elementum elit at dui tristique feugiat. Mauris convallis, mi at mattis malesuada, neque nulla volutpat dolor, hendrerit faucibus eros nibh ut nunc.").FontSize(10).Justify();

        col.Item().PaddingTop(10).Text("Experience").LetterSpacing(0.05f).ExtraBlack().Bold().FontColor(Colors.Black).FontSize(20).AlignStart();
        col.Item().LineHorizontal(1).LineColor(Colors.Black);

        for (int i = 0; i < Model.noOfExperience; i++)
        {
            ComposeJobExp(col);
        }

        col.Item().PaddingTop(15).ShowEntire().Row(row => row.RelativeItem().Column(col =>
        {
            col.Item().Text("Reference").ExtraBold().FontSize(15);
            col.Item().LineHorizontal(1).LineColor(Colors.Black);

            col.Item().Row(row =>
            {
                row.RelativeItem().PaddingTop(10).Column(col =>
                {
                    col.Item().Text("Name").Bold();
                    col.Item().Text("Job Position, Company Name").Light();

                    col.Item().Text("Email: nospamsajal@gmail.com");
                    col.Item().Text("Phone: 9865206734");
                });

                row.RelativeItem().PaddingTop(10).Column(col =>
                {
                    col.Item().Text("Name").Bold();
                    col.Item().Text("Job Position, Company Name").Light();

                    col.Item().Text("Email: nospamsajal@gmail.com");
                    col.Item().Text("Phone: 9865206734");
                });
            });


        }));
    }

    void ComposeJobExp(ColumnDescriptor col)
    {
        TextStyle dateStyle = TextStyle.Default.FontColor(Colors.Grey.Medium);
        TextStyle positionStyle = TextStyle.Default.FontColor(Colors.Grey.Medium).Weight(FontWeight.Bold);

        col.Item().PaddingTop(10).ShowEntire().Container().Row(row =>
        {
            row.ConstantItem(20).Column(col =>
            {
                col.Item().MinHeight(80).LineVertical(1).LineColor(Colors.Black);
            });

            row.RelativeItem().Column(col =>
            {
                col.Item().Text("2019 - 2022").Style(dateStyle);
                col.Item().Text("Company Name 1 123 Anywhere St., Any City");
                col.Item().Text("Job Position Here").Style(positionStyle);

                col.Item().PaddingTop(5).Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit, Nullam pharetra in lorem at laoreet. Donec hendrerit libero eget est tempor, quis tempus arcu elementum. In elementum elit at dui tristique feugiat. Mauris convallis, mi at mattis malesuada, neque nulla volutpat dolor, hendrerit faucibus eros nibh ut nunc.").FontSize(10).Justify();
            });
        });
    }
}
