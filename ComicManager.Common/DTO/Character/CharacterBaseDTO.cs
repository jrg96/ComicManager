namespace ComicManager.Common.DTO.Character
{
    public class CharacterBaseDTO : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
