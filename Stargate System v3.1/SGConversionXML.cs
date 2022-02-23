using System;
using System.Text;
using Server.Items;
using Server.Network;
using System.Collections;
using Server.Mobiles;

namespace Server.Items
{
	public class SGConversionXML : Item
	{
        private static string m_SGSaveNewFilePath = Path.Combine(Core.BaseDirectory, "Data\\Stargate Data"); //Save Directory
        private static string m_SGNewFileName = "SGData-NEW-FORMAT.xml"; // File Name

        public static string SGNewFilePath = Path.Combine(m_SGSaveNewFilePath, m_SGNewFileName);

		[Constructable]
		public SGConversionXML () : base( 0x0EDE )
		{
			Movable = false;
			Hue = 6;
			Name = "Stargate XML Conversion Stone";
		}

        public override void OnDoubleClick(Mobile from)
        {
            World.Broadcast(0x35, true, "Generating New XML Format From OLD XML Format...");
            SGSaveNewFile(SGNewFilePath);
            World.Broadcast(0x35, true, "Finished... SHUTDOWN & Replace Your Stargate System v3.0 With The NEW v3.1 System before you continue.");
        }

        public static void SGSaveNewFile(string SGNewFilePath)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration Declaration = doc.CreateXmlDeclaration("1.0", "utf-8", "");
            doc.AppendChild(Declaration);
            XmlNode StargateAddresses = doc.CreateNode(XmlNodeType.Element, "StargateAddresses", "");

            foreach (SGEntry entry in SGList)
            {
                XmlNode StargateEntry = doc.CreateNode(XmlNodeType.Element, "StargateEntry", "");

                XmlNode SGHideDial = doc.CreateNode(XmlNodeType.Element, "SGHideDial", "false");
                // SGHideDial.InnerText = entry.extradata.ToString();
                // StargateEntry.AppendChild(SGHideDial);

                XmlNode SGX = doc.CreateNode(XmlNodeType.Element, "SGX", "");
                SGX.InnerText = entry.SGX.ToString();
                StargateEntry.AppendChild(SGX);

                XmlNode SGY = doc.CreateNode(XmlNodeType.Element, "SGY", "");
                SGY.InnerText = entry.SGY.ToString();
                StargateEntry.AppendChild(SGY);

                XmlNode SGZ = doc.CreateNode(XmlNodeType.Element, "SGZ", "");
                SGZ.InnerText = entry.SGZ.ToString();
                StargateEntry.AppendChild(SGZ);

                XmlNode SGFacing = doc.CreateNode(XmlNodeType.Element, "SGFacing", "");
                SGFacing.InnerText = entry.SGFacing.ToString();
                StargateEntry.AppendChild(SGFacing);

                XmlNode SGStyle = doc.CreateNode(XmlNodeType.Element, "SGStyle", "");
                SGStyle.InnerText = entry.SGStyle.ToString();
                StargateEntry.AppendChild(SGStyle);

                XmlNode SGCanBeUsed = doc.CreateNode(XmlNodeType.Element, "SGCanBeUsed", "");
                SGCanBeUsed.InnerText = entry.SGCanBeUsed.ToString();
                StargateEntry.AppendChild(SGCanBeUsed);

                XmlNode SGBeingUsed = doc.CreateNode(XmlNodeType.Element, "SGBeingUsed", "");
                SGBeingUsed.InnerText = entry.SGBeingUsed.ToString();
                StargateEntry.AppendChild(SGBeingUsed);

                XmlNode SGEnergy = doc.CreateNode(XmlNodeType.Element, "SGEnergy", "");
                SGEnergy.InnerText = entry.SGEnergy.ToString();
                StargateEntry.AppendChild(SGEnergy);

                XmlNode SGHidden = doc.CreateNode(XmlNodeType.Element, "SGHidden", "");
                SGHidden.InnerText = entry.SGHidden.ToString();
                StargateEntry.AppendChild(SGHidden);

                XmlNode SGDiscovered = doc.CreateNode(XmlNodeType.Element, "SGDiscovered", "");
                SGDiscovered.InnerText = entry.SGDiscovered;
                StargateEntry.AppendChild(SGDiscovered);

                XmlNode SGLocationName = doc.CreateNode(XmlNodeType.Element, "SGLocationName", "");
                SGLocationName.InnerText = entry.SGLocationName;
                StargateEntry.AppendChild(SGLocationName);

                XmlNode SGFacetCode = doc.CreateNode(XmlNodeType.Element, "SGFacetCode", "");
                SGFacetCode.InnerText = entry.SGFacetCode.ToString();
                StargateEntry.AppendChild(SGFacetCode);

                XmlNode SGAddressCode1 = doc.CreateNode(XmlNodeType.Element, "SGAddressCode1", "");
                SGAddressCode1.InnerText = entry.SGAddressCode1.ToString();
                StargateEntry.AppendChild(SGAddressCode1);

                XmlNode SGAddressCode2 = doc.CreateNode(XmlNodeType.Element, "SGAddressCode2", "");
                SGAddressCode2.InnerText = entry.SGAddressCode2.ToString();
                StargateEntry.AppendChild(SGAddressCode2);

                XmlNode SGAddressCode3 = doc.CreateNode(XmlNodeType.Element, "SGAddressCode3", "");
                SGAddressCode3.InnerText = entry.SGAddressCode3.ToString();
                StargateEntry.AppendChild(SGAddressCode3);

                XmlNode SGAddressCode4 = doc.CreateNode(XmlNodeType.Element, "SGAddressCode4", "");
                SGAddressCode4.InnerText = entry.SGAddressCode4.ToString();
                StargateEntry.AppendChild(SGAddressCode4);

                XmlNode SGAddressCode5 = doc.CreateNode(XmlNodeType.Element, "SGAddressCode5", "");
                SGAddressCode5.InnerText = entry.SGAddressCode5.ToString();
                StargateEntry.AppendChild(SGAddressCode5);

                StargateAddresses.AppendChild(StargateEntry);
            }

            doc.AppendChild(StargateAddresses);

            doc.Save(SGNewFilePath);
        }

        public SGConversionXML(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();
		}
	}
}