import { LightComboBoxItemContainer }   from './light.combo.box.item.container';

export class LightComboBoxModelContainer {
    constructor(
        public Items: LightComboBoxItemContainer[],
        public SelectedValue: string
    ) { }
}