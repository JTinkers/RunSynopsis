import { IApiUser } from './IApiUser'

export interface IApiService
{
    get user(): IApiUser | null;
    set user(user: IApiUser | null);
    signIn(username: string, password: string): Promise<any>;
    signOut(): Promise<any>;
    query(query: string, variables?: any): Promise<any>;
    mutation(query: string, variables?: any): Promise<any>;
}