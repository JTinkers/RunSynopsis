import { App } from 'vue'
import Markdown from 'vue3-markdown-it'

export function useMarkdown(app: App<Element>)
{
    return app
        .component('Markdown', Markdown)
        .use(Markdown)
}