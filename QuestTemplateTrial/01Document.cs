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
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine it with the relative path to the image
        string imagePath = Path.Combine(baseDirectory, "avatar-modified.png");
        col.Item().AlignCenter().Width(100).Image(imagePath);

        col.Item().PaddingTop(40).Text("Contact").Bold().FontColor(Colors.White).FontSize(20).AlignCenter();
        col.Item().PaddingTop(10).PaddingLeft(40).LineHorizontal(1).LineColor(Colors.White);

    }

    void ComposeMain(ColumnDescriptor col)
    {
        col.Item().Text(text =>
        {
            text.Span("Mariana").ExtraBlack().FontColor(Colors.Black).FontSize(30);
            text.Span(" Anderson").Light().FontColor(Colors.Black).FontSize(30);
        });

        col.Item().Text("Marketing Manager")
            .Light()
            .LetterSpacing(0.4f);

        col.Item().PaddingTop(5).Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit, Nullam pharetra in lorem at laoreet. Donec hendrerit libero eget est tempor, quis tempus arcu elementum. In elementum elit at dui tristique feugiat. Mauris convallis, mi at mattis malesuada, neque nulla volutpat dolor, hendrerit faucibus eros nibh ut nunc.").FontSize(10).Justify();

        col.Item().PaddingTop(10).Text("Experience").LetterSpacing(0.05f).ExtraBlack().Bold().FontColor(Colors.Black).FontSize(20).AlignStart();
        col.Item().LineHorizontal(1).LineColor(Colors.Black);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);
        ComposeJobExp(col);

    }

    void ComposeJobExp(ColumnDescriptor col)
    {
        col.Item().ShowEntire().Container().Row(row =>
        {
            //Gives line
            //row.ConstantItem(20).PaddingTop(3).LineVertical(1).LineColor(Colors.Black);

            //DOes not give line

            //row.ConstantItem(20).Column(col =>
            //{
            //    col.Item().AlignCenter().LineVertical(1).LineColor(Colors.Black);
            //});

            row.RelativeItem().Column(col =>
            {
                col.Item().Text("2019 - 2022");
                col.Item().Text("Company Name 1 123 Anywhere St., Any City");
                col.Item().Text("Job Position Here");

                col.Item().PaddingTop(5).Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit, Nullam pharetra in lorem at laoreet. Donec hendrerit libero eget est tempor, quis tempus arcu elementum. In elementum elit at dui tristique feugiat. Mauris convallis, mi at mattis malesuada, neque nulla volutpat dolor, hendrerit faucibus eros nibh ut nunc.").FontSize(10).Justify();
            });
        });
    }
}
