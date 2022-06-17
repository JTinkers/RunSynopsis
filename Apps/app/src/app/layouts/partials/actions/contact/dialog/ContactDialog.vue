<template>
    <Dialog id='dialog'
        title='Contact'
        icon='mail'
        v-model:show='show'
    >
        <Transition name='fade'
            mode='out-in' 
            appear
        >
            <NoteBlock v-if='note' 
                :type='note.type' 
                :text='note.text'
                :decay='note.decay'
                @decayed='close'
            />
        </Transition>
        <InputField name='title'
            label='Title' 
            v-model='form.title'
        />
        <InputField name='mail'
            label='Mail' 
            v-model='form.mail'
        />
        <InputArea name='body'
            label='Message'
            :rows='6' 
            v-model='form.body'
        />
        <Button text='Send' 
            :type='ButtonType.Primary'
            :disabled='!canSend'
            @click='send'
        />
    </Dialog>
</template>

<script lang='ts' setup>
    import { onErrorCaptured, ref, useAttrs, computed } from 'vue'
    import { NoteType } from '@/app/components/notes/NoteType'
    import { INoteProps } from '@/app/components/notes/INoteProps'
    import { ButtonType } from '@/app/components/controls/buttons/ButtonType'
    import { useService } from '@/core'
    import { IApiService } from '@/core/domain/api'
    import { contactSubmitMutation } from './gql/contactSubmitMutation'
    import { useForm } from 'vee-validate'
    import * as yup from 'yup'

    const emit = defineEmits(['update:show'])
    const attrs = useAttrs()
    const api = useService<IApiService>('IApiService')
    const note = ref<INoteProps | null>(null)
    const sent = ref(false)

    const schema = yup.object(
    {
        title: yup
            .string()
            .required('Title is required'),
        mail: yup
            .string()
            .email('Invalid email address')
            .required('Mail is required'),
        body: yup
            .string()
            .required('Message is required')
            .min(4, 'Message has to be at least 4 characters')
    })

    const { values: form, meta } = useForm(
    {
        validationSchema: schema,
    })

    const canSend = computed(() => !(sent.value || !meta.value.valid ))
    
    const show = computed(
    {
        get()
        {
            return attrs.show as boolean
        },
        set(value: boolean)
        {
            emit('update:show', value)
        }
    })

    async function send()
    {
        note.value = null

        await api.mutation(contactSubmitMutation, { message: form })

        sent.value = true

        note.value =
        {
            type: NoteType.Success,
            text: 'Message has been sent',
            decay: 3000
        }
    }

    async function close()
    {
        show.value = false
    }

    onErrorCaptured(err =>
    {
        note.value =
        {
            type: NoteType.Error,
            text: err.message,
            decay: 0
        }
    })
</script>

<style lang='scss' scoped>
    :deep(#dialog)
    {
        display: flex;
        grid-row-gap: 16px;
        flex-direction: column;
        flex-grow: 1;
        max-width: 400px;
    }
</style>