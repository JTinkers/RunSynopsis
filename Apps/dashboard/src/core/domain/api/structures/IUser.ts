import { IPermission } from './IPermission'

export interface IUser
{
    id: string;
    avatarUrl: string;
    homepageUrl: string;
    bio: string;
    createdAt: Date;
    lastSeenAt: Date;
    mail: string;
    nickname: string;
    permissions: Array<IPermission>;
}