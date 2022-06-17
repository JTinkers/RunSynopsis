<template>
    <div id='form'>
        <InputField name='username' 
            label='Username' 
            v-model='form.username'
        />
        <InputArea name='bio' 
            placeholder='Bio' 
            v-model='form.bio'
        />
    </div>
</template>

<script lang='ts' setup>
    import { useForm } from 'vee-validate'
    import * as yup from 'yup'

    const schema = yup.object(
    {
        username: yup
            .string()
            .required('Username is required')
            .min(4, 'Minimum of 4 characters are required'),
        bio: yup
            .string()
            .required('Bio is required')
            .min(16, 'Minimum of 16 characters are required')
    })

    const { values: form } = useForm(
    {
        validationSchema: schema,
        initialValues:
        {
            username: 'init',
            bio: ''
        }
    })
</script>

<style lang='scss' scoped>
    #form
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
        padding: 64px;
        width: 400px;
    }
</style>