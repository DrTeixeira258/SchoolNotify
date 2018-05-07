export class Token {
  id: number = null;
  userId: string = null;
  telefoneResp: number = null;

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}