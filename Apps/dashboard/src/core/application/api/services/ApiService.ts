import { Client } from '@urql/vue'
import { IApiService, IApiUser } from '@/core/domain/api'
import { ApiStore } from './ApiStore'
import { reactive, ref } from 'vue'
import { signInMutation } from './queries/signInMutation'
import { signOutMutation } from './queries/signOutMutation'
import { whoIsMeQuery } from './queries/whoIsMeQuery'

export class ApiService implements IApiService
{    
    private _localStorageKey = 'api:store'

    private _store!: ApiStore;

    private _client: Client;
    
    constructor(client: Client)
    {
        const stored: any | null = JSON.parse(localStorage.getItem(this._localStorageKey) || 'null')
        const store = stored ?? new ApiStore()
        
        this._client = client
        this._store = reactive(store)
        this._store.user = ref(store.user)
    }

    get user(): IApiUser | null
    {
        return this._store.user
    }

    set user(user: IApiUser | null)
    {
        this._store.user = user

        localStorage.setItem(this._localStorageKey, JSON.stringify(this._store))
    }

    async signIn(username: string, password: string): Promise<boolean>
    {
        const response = await this.mutation(signInMutation, { username, password })

        const data = response.signedIn

        if (!data)
            return false

        this.user = (await this.query(whoIsMeQuery)).whoIsMe

        return data
    }

    async signOut(): Promise<boolean>
    {
        const response = await this.mutation(signOutMutation)

        const data = response.signedOut

        if (!data)
            return false

        this.user = null

        return data
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