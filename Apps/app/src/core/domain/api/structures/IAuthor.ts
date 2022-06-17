export interface IAuthor
{
    id: string;
    nickname: string;
    avatarUrl: string;
    bio?: string | null;
    homepageUrl?: string | null;
}