export class Post {
  category: number  = 0;
  content: string | undefined;
  dislikeCounter: number | undefined;
  id: string | undefined;
  likeCounter: number | undefined;
  userId!: string;
}
