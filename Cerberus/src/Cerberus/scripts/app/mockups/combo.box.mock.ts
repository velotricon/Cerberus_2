import { ComboBoxModelContainer }       from '../containers/combo.box.model.container';
import { ComboBoxItemContainer }        from '../containers/combo.box.item.container';

export const COMBO_BOX_MOCK = new ComboBoxModelContainer(
    [
        new ComboBoxItemContainer("1", ["Jan", "Kowalski"]),
        new ComboBoxItemContainer("2", ["Zbyszek", "Zbyszkowski"]),
        new ComboBoxItemContainer("3", ["Jadwiga", "Stonoga"]),
        new ComboBoxItemContainer("4", ["Jarosław", "Kaczyński"]),
        new ComboBoxItemContainer("5", ["Władysław", "Cienki"]),
        new ComboBoxItemContainer("6", ["Abra", "Cadabra"])
    ], null
);