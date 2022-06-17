import { Client } from '@urql/vue'
import { IApiService } from '@/core/domain/api'

export class ApiService implements IApiService
{    
    private _client: Client;
    
    constructor(client: Client)
    {
        this._client = client
    }

    async query(query: string, variables?: any): Promise<any>
    {
        const response = await this._client.query(query, variables)
            .toPromise()

        const error = response.error

        if (error?.graphQLErrors.length)
            throw new Error(error.graphQLErrors[0].message)

        if (error?.networkError)
            throw new Error(error.networkError.message)

        return response.data
    }

    async mutation(query: string, variables?: any): Promise<any>
    {
        const response = await this._client.mutation(query, variables)
            .toPromise()

        const error = response.error

        if (error?.graphQLErrors.length)
            throw new Error(error.graphQLErrors[0].message)

        if (error?.networkError)
            throw new Error(error.networkError.message)

        return response.data
    }
}