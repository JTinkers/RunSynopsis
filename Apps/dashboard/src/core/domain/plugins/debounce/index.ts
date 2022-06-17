import { App } from 'vue'

export function debounce(fn: any, delay = 500)
{
    let timerId: ReturnType<typeof setTimeout>

    return function (this: any, ...args: any)
    {
        clearTimeout(timerId)

        timerId = setTimeout(() => fn.apply(this, args), delay)
    }
}

export function useDebounce(app: App<Element>): App<Element>
{
    // do nothing
    
    return app
}