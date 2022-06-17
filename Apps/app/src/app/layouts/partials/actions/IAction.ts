import { Component } from 'vue';

export interface IAction
{
    label: string;
    icon: string;
    iconClass?: string;
    isVisible: () => boolean;
    isActive?: () => boolean;
    onClick?: () => void;
    component?: Component;
}