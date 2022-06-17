<template>
    <div id='newsletter'>
        <span id='label' v-text='"FOLLOW US"'/>
        <Transition name='fade'
            mode='out-in' 
            appear
        >
            <div v-if='showButton' id='controls'>
                <InputField id='input'
                    name='mail'
                    placeholder='E-mail'
                    :validation-mode='InputValidationMode.None'
                    v-model='form.mail'
                />
                <Button id='button' @click='send'>
                    <span class='material-symbols-outlined' v-text='"done"'/>
                </Button>
            </div>
            <div v-else>
                <Note :type='NoteType.Success' :text='successText'/>
            </div>
        </Transition>
    </div>
</template>

<script lang='ts' setup>
    import { computed, ref } from 'vue'
    import { useService } from '@/core'
    import { IApiService } from '@/core/domain/api'
    import { signUpMutation } from './gql/signUpMutation'
    import { useForm } from 'vee-validate'
    import { InputValidationMode } from '@/app/components/controls/inputs/InputValidationMode'
    import { NoteType } from '@/app/components/notes/NoteType'
    import * as yup from 'yup'

    const api = useService<IApiService>('IApiService')
    const sent = ref(false)
    const successText = 'You\'ve been signed-up!'

    const schema = yup.object(
    {
        mail: yup
            .string()
            .required('E-mail address is required')
            .email('E-mail must be of a valid format')
    })

    const { values: form, validate } = useForm(
    {
        validationSchema: schema,
    })

    const showButton = computed(() => !sent.value)

    async function send()
    {
        if(!(await validate()).valid)
            return

        await api.mutation(signUpMutation, { ...form })

        sent.value = true
    }
</script>

<style lang='scss' scoped>
    #newsletter
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 16px;
        border-radius: 5px;
        background: scale-color($background, $lightness: -2.5%);
    }

    #label
    {
        font-size: 11px;
        font-family: $font-family-secondary;
        letter-spacing: 1px;
        text-transform: uppercase;
    }

    #controls
    {
        display: flex;
        grid-column-gap: 8px;;
    }

    #input
    {
        flex-grow: 1;
    }

    #button
    {
        align-self: flex-start;
        padding: 6px;
    }
</style>