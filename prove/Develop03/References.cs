// Reference.cs

namespace ScriptureGame
{
    public class Reference
    {
        public string ReferenceText { get; set; }

        public Reference(string reference)
        {
            ReferenceText = reference;
        }

        public override string ToString()
        {
            return ReferenceText;
        }
    }
}
