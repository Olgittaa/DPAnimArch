namespace AnimArch.Visualization.Diagrams
{
    public class StructuralDiagram:ArchitecturalDiagramDecorator
    {
        private Diagram classDiagram;
        private Diagram objectDiagram;


        public StructuralDiagram(Diagram diagram) : base(diagram)
        {
            
        }
    }
}