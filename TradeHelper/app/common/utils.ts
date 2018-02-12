export namespace Utils {
    export function getNewGUID(): string {
        var d: number = new Date().getTime();
        var newGuid: string = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c: string) => {
            var r: number = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return newGuid;
    }

    export function getEmptyGUID(): string {
        return '00000000-0000-0000-0000-000000000000';
    }
}