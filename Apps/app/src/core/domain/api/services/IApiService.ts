export interface IApiService
{
    query(query: string, variables?: any): Promise<any>;
    mutation(query: string, variables?: any): Promise<any>;
}