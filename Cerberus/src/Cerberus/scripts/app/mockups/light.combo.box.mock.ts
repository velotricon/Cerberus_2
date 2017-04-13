import { LightComboBoxModelContainer }      from '../containers/light.combo.box.model.container';
import { LightComboBoxItemContainer }       from '../containers/light.combo.box.item.container';

export const LIGHT_COMBO_MODEL: LightComboBoxModelContainer = new LightComboBoxModelContainer([
        new LightComboBoxItemContainer("1", "Option 1"),
        new LightComboBoxItemContainer("2", "Option 2"),
        new LightComboBoxItemContainer("3", "Option 3"),
        new LightComboBoxItemContainer("4", "Option 4")
    ], "3");