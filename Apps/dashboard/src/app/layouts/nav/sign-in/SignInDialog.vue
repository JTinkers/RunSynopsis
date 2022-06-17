<template>
    <Dialog ref='dialog' 
        v-bind='$attrs' 
        modal
    >
        <template #header>
            <h5>Sign-in</h5>
        </template>
        <div id='form'>
            <InputText v-model='form.username'/>
            <InputText v-model='form.password'/>
        </div>
        <template #footer>
            <Button class='p-button-secondary p-button-text' 
                label='Go'
                @click='go'
            />
        </template>
    </Dialog>
</template>

<script lang='ts' setup>
    import { reactive, ref } from 'vue'
    import { useService } from '@/core'
    import { IApiService } from '@/core/domain/api'
    import Dialog from 'primevue/dialog'

    const api = useService<IApiService>('IApiService')
    const dialog = ref<Dialog>()
    const form = reactive(
    {
        username: '',
        password: ''
    })

    async function go()
    {
        await api.signIn(form.username, form.password)

        dialog.value?.$emit('update:visible', false)
    }
</script>

<style lang='scss' scoped>
    #form
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        min-width: 400px;
    }
</style>