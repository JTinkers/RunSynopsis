import { CookiePolicyState } from '@/core/domain/cookies'
import { Ref, ref } from 'vue'

export class CookiePolicyStore
{
    private _localStorageKey = 'cookie-policy:state'
    
    private _state = ref(CookiePolicyState.Pending)

    constructor()
    {
        const state: CookiePolicyState | null 
            = localStorage.getItem(this._localStorageKey) as CookiePolicyState

        this.state = state !== null ? state : this._state.value
    }

    public get state(): CookiePolicyState
    {
        return this._state.value
    }

    public set state(value: CookiePolicyState) 
    {
        this._state.value = value

        localStorage.setItem(this._localStorageKey, this._state.value)
    }
}