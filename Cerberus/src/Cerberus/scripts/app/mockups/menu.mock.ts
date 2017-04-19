import { MenuItem } from '../services/menu.service'

export const MENU_ITEMS: MenuItem[] = [
    { Label: 'Home', Href: '/home' },
    { Label: 'TEST', Href: '/test' },
    { Label: 'Person ?', Href: '/person/view/1' },
    { Label: 'Person list', Href: '/persons' },
    { Label: 'Add new person', Href: '/person/add' },
    { Label: 'Register', Href: '/register' },
    { Label: 'Log in', Href: '/login' },
    { Label: 'Form test', Href: '/formtest' }
];