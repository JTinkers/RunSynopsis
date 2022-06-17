<template>
    <Dialog ref='dialog' 
        v-bind='$attrs' 
        modal
    >
        <div id='inputs'>
            <InputText placeholder='Name' v-model='form.name'/>
            <Textarea id='description' 
                placeholder='Description' 
                v-model='form.description'
            />
            <Button label='Save' @click='save'/>
        </div>
    </Dialog>
</template>

<script lang='ts' setup>
    import { PropType, reactive, ref, watch } from 'vue'
    import { useService } from '@/core'
    import { IApiService, ITag } from '@/core/domain/api'
    import { updateTagMutation } from './gql/updateTagMutation'
    import Dialog from 'primevue/dialog'

    const api = useService<IApiService>('IApiService')
    const dialog = ref<Dialog>()

    const props = defineProps(
    {
        tag:
        {
            type: Object as PropType<ITag>,
            required: true,
        },
    })

    const form = reactive(
    {
        name: '',
        description: '',
    })

    async function save()
    {
        await api.mutation(updateTagMutation, { request: { id: props.tag.id, ...form } })

        dialog.value?.$emit('update:visible', false)
    }

    watch(() => props.tag, async () =>
    {
        form.name = props.tag.name
        form.description = props.tag.description
    }, { immediate: true })
</script>

<style lang='scss' scoped>
    #inputs
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 8px;
        min-width: 400px;
        min-height: 200px;
    }

    #description
    {
        flex-grow: 1;
    }
</style>