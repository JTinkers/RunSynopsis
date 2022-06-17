import { NoteType } from './NoteType'

export interface INoteProps 
{ 
    text: string, 
    type: NoteType, 
    decay?: number
}