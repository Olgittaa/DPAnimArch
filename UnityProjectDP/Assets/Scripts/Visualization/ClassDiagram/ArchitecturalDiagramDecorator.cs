namespace AnimArch.Visualization.Diagrams
{
    public class ArchitecturalDiagramDecorator : Diagram
    {
        protected Diagram Diagram;

        protected ArchitecturalDiagramDecorator(Diagram diagram)
        {
            Diagram = diagram;
        }

        public override void Generate()
        {
            Diagram.Generate();
        }
    }
}