<template>
    <div class='input'>
        <div class='control'>
            <label v-if='label'>
                <span class='label' v-text='label'/>
            </label>
            <slot :props='props'
                :value='value'
                :on-input='onInput' 
                :on-blur='onBlur'
            />
        </div>
        <Transition name='fade'
            mode='out-in' 
            appear
        >
            <div v-show='showErrors' class='error-label'>
                <span class='error-label-icon material-symbols-outlined' v-text='"error"'/>
                <p class='error-label-message' v-text='errorMessage'/>
            </div>
        </Transition>
    </div>
</template>

<script lang='ts' setup>
    import { ref, computed, PropType } from 'vue'
    import { useField } from 'vee-validate'
    import { InputValidationMode } from './InputValidationMode'

    const emits = defineEmits(['update:modelValue'])

    const props = defineProps(
    {
        type: 
        {
            type: String,
            default: 'text'
        },
        name:
        {
            type: String
        },
        label:
        {
            type: String,
            default: ''
        },
        placeholder:
        {
            type: String,
            default: ''
        },
        modelValue:
        {
            type: String,
            default: ''
        },
        validationMode:
        {
            type: Number as PropType<InputValidationMode>,
            default: InputValidationMode.Change | InputValidationMode.Blur
        }
    })

    const name = ref(props.name || '')
    const hasValidationModeChange = ref((props.validationMode & InputValidationMode.Change) == InputValidationMode.Change)

    const
    {
        meta,
        errorMessage,
        handleBlur,
        handleChange,
    } = useField(name, undefined, { validateOnValueUpdate: hasValidationModeChange.value })

    const value = computed(
    {
        get()
        {
            return props.modelValue
        },
        set(value: string)
        {
            emits('update:modelValue', value)
        }
    })

    const showErrors = computed(() => !meta.valid && errorMessage.value)

    function onInput(e: any)
    {
        handleChange(e, hasValidationModeChange.value)

        value.value = e.target.value
    }

    function onBlur(e: any)
    {
        const hasValidationModeBlur = (props.validationMode & InputValidationMode.Blur) 
            == InputValidationMode.Blur

        if (!hasValidationModeBlur)
            return

        handleBlur(e)
    }
</script>

<style lang='scss' scoped>
    .input
    {
        display: flex;
        flex-direction: column;
    }

    .control
    {
        display: flex;
        flex-direction: column;
        min-height: 36px;
        border: 1px solid scale-color($background, $lightness: -10%);
        border-radius: 5px;

        &:focus-within
        {
            border-color: scale-color($background, $lightness: -30%);
        }
    }

    label
    {
        position: relative;
    }

    .label
    {
        position: absolute;
        top: 0;
        left: 0;
        transform: translateY(-50%) translateX(8px);
        font-size: 12px;
        font-family: $font-family-secondary;
        color: $foreground;
        background: $background;
    }

    .error-label
    {
        display: flex;
        align-self: flex-start;
        padding: 2px 8px 2px 2px;
        margin-top: 8px;
        grid-column-gap: 2px;
        border-radius: 64px;
        align-items: center;
        border: 1px solid scale-color($red, $lightness: 65%);
        background: scale-color($red, $lightness: 85%);
        color: scale-color($red, $lightness: -45%);
    }

    .error-label-icon
    {
        font-size: 16px;
        font-variation-settings:
            'FILL' 0,
            'wght' 300,
            'GRAD' 100,
            'opsz' 16;
    }

    .error-label-message
    {
        font-size: 11px;
        font-family: $font-family-secondary;
        white-space: nowrap;
        line-height: 1;
    }
</style>