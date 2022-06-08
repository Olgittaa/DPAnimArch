namespace AnimArch.Visualization.Diagrams
{
    public class PackageDiagram : ArchitecturalDiagramDecorator
    {
        public PackageDiagram(Diagram diagram) : base(diagram)
        {
            _diagram = diagram;
        }

        public void AddPackages()
        {
            
        }
    }
}

