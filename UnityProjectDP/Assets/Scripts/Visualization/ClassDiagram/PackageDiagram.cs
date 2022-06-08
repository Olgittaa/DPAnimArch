namespace AnimArch.Visualization.Diagrams
{
    public class PackageDiagram : ArchitecturalDiagramDecorator
    {
        public PackageDiagram(Diagram diagram) : base(diagram)
        {
            Diagram = diagram;
        }

        public void AddPackages()
        {
            
        }
    }
}

