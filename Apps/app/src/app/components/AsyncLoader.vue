<template>
    <div class='async-loader'>
        <Suspense>
            <slot/>
            <template #fallback>
                <div class='indicator'>
                    <Transition name='fade'
                        mode='out-in' 
                        appear
                    >
                        <Spinner v-if='!error'/>
                        <Note v-else 
                            :type='NoteType.Error' 
                            :text='error.message'
                        />
                    </Transition>
                </div>
            </template>
        </Suspense>
    </div>
</template>

<script lang='ts' setup>
    import { onErrorCaptured, ref } from 'vue'
    import { NoteType } from './notes/NoteType'

    const error = ref<Error | null>(null)

    onErrorCaptured(err =>
    {
        error.value = err
    })
</script>

<style lang='scss' scoped>
    .async-loader
    {
        display: contents;
        align-items: center;
        justify-content: center;
        flex-grow: 1;
    }

    .indicator
    {
        display: flex;
        align-items: center;
        justify-content: center;
        flex-grow: 1;
    }
</style>