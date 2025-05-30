// Copyright © Spatial. All rights reserved.

using Spatial.Networking;

namespace Ignite.Contracts.Objects;

/// <summary>
/// A <see cref="ProtocolBuffer"/> for <see cref="NETCOMMAND.NC_BRIEFINFO_LOGINCHARACTER_CMD"/>.
/// </summary>
public class PROTO_NC_BRIEFINFO_LOGINCHARACTER_CMD : ProtocolBuffer
{
    /// <summary>
    /// The character's handle.
    /// </summary>
    public ushort handle;

    /// <summary>
    /// The character's name.
    /// </summary>
    public string charid;

    /// <summary>
    /// The character's coordinates.
    /// </summary>
    public SHINE_COORD_TYPE coord;

    /// <summary>
    /// The character's mode.
    /// </summary>
    public byte mode;

    /// <summary>
    /// The character's class.
    /// </summary>
    public byte chrclass;

    /// <summary>
    /// The character's shape.
    /// </summary>
    public PROTO_AVATAR_SHAPE_INFO shape;

    /// <summary>
    /// The character's uncamped data.
    /// </summary>
    public CHARBRIEFINFO_NOTCAMP notcamp;

    /// <summary>
    /// The character's camp data.
    /// </summary>
    public CHARBRIEFINFO_CAMP camp;

    /// <summary>
    /// The character's booth data.
    /// </summary>
    public CHARBRIEFINFO_BOOTH booth;

    /// <summary>
    /// The character's ride data.
    /// </summary>
    public CHARBRIEFINFO_RIDE ride;

    /// <summary>
    /// The character's current polymorph.
    /// </summary>
    public ushort polymorph;

    /// <summary>
    /// The character's current emote.
    /// </summary>
    public STOPEMOTICON_DESCRIPT emoticon;

    /// <summary>
    /// The character's title.
    /// </summary>
    public CHARTITLE_BRIEFINFO chartitle;

    /// <summary>
    /// The character's abnormal states.
    /// </summary>
    public ABNORMAL_STATE_BIT abstatebit;

    /// <summary>
    /// The character's guild identification number.
    /// </summary>
    public uint myguild;

    /// <summary>
    /// The character's type.
    /// </summary>
    public byte type;

    /// <summary>
    /// Whether or not the character is a member of a guild academy.
    /// </summary>
    public bool isGuildAcademyMember;

    /// <summary>
    /// Whether or not the character has auto-pickup enabled.
    /// </summary>
    public bool IsAutoPick;

    /// <summary>
    /// The character's current level.
    /// </summary>
    public byte Level;

    /// <summary>
    /// The character's current animation.
    /// </summary>
    public string sAnimation;

    /// <summary>
    /// The character's mount handle.
    /// </summary>
    public ushort nMoverHnd;

    /// <summary>
    /// The character's mount slot number.
    /// </summary>
    public byte nMoverSlot;

    /// <summary>
    /// The character's kingdom quest team.
    /// </summary>
    public byte nKQTeamType;

    /// <summary>
    /// Whether or not the character is using an item minipet.
    /// </summary>
    public bool IsUseItemMinimon;

    /// <summary>
    /// Deserialize the <see cref="ProtocolBuffer"/>.
    /// </summary>
    public override void Deserialize()
    {
        handle = ReadUInt16();
        charid = ReadString(20);
        coord = Read<SHINE_COORD_TYPE>();
        mode = ReadByte();
        chrclass = ReadByte();
        shape = Read<PROTO_AVATAR_SHAPE_INFO>();

        switch ((ObjectMode) mode)
        {
            case ObjectMode.Riding:
                ride = Read<CHARBRIEFINFO_RIDE>();
                break;
            case ObjectMode.Resting:
                camp = Read<CHARBRIEFINFO_CAMP>();
                break;
            case ObjectMode.Vending:
                booth = Read<CHARBRIEFINFO_BOOTH>();
                break;
            default:
                notcamp = Read<CHARBRIEFINFO_NOTCAMP>();
                break;
        }

        polymorph = ReadUInt16();
        emoticon = Read<STOPEMOTICON_DESCRIPT>();
        chartitle = Read<CHARTITLE_BRIEFINFO>();
        abstatebit = Read<ABNORMAL_STATE_BIT>();
        myguild = ReadUInt32();
        type = ReadByte();
        isGuildAcademyMember = ReadBoolean();
        IsAutoPick = ReadBoolean();
        Level = ReadByte();
        sAnimation = ReadString(32);
        nMoverHnd = ReadUInt16();
        nMoverSlot = ReadByte();
        nKQTeamType = ReadByte();
        IsUseItemMinimon = ReadBoolean();
    }

    /// <summary>
    /// Serialize the <see cref="ProtocolBuffer"/>.
    /// </summary>
    public override void Serialize()
    {
        Write(handle);
        Write(charid, 20);
        Write(coord);
        Write(mode);
        Write(chrclass);
        Write(shape);

        switch ((ObjectMode) mode)
        {
            case ObjectMode.Riding:
                Write(ride);
                break;
            case ObjectMode.Resting:
                Write(camp);
                break;
            case ObjectMode.Vending:
                Write(booth);
                break;
            default:
                Write(notcamp);
                break;
        }

        Write(polymorph);
        Write(emoticon);
        Write(chartitle);
        Write(abstatebit);
        Write(myguild);
        Write(type);
        Write(isGuildAcademyMember);
        Write(IsAutoPick);
        Write(Level);
        Write(sAnimation, 32);
        Write(nMoverHnd);
        Write(nMoverSlot);
        Write(nKQTeamType);
        Write(IsUseItemMinimon);
    }

    /// <summary>
    /// Dispose of the <see cref="ProtocolBuffer"/>.
    /// </summary>
    public override void Dispose()
    {
        coord.Dispose();
        shape.Dispose();
        notcamp?.Dispose();
        camp?.Dispose();
        booth?.Dispose();
        ride?.Dispose();
        emoticon.Dispose();
        chartitle.Dispose();
        abstatebit.Dispose();

        base.Dispose();
    }
}
