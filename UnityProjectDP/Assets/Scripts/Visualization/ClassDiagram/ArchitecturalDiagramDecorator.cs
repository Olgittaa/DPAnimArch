namespace AnimArch.Visualization.Diagrams
{
    public class ArchitecturalDiagramDecorator : Diagram
    {
        protected Diagram _diagram;

        protected ArchitecturalDiagramDecorator(Diagram diagram)
        {
            _diagram = diagram;
        }
    }
}