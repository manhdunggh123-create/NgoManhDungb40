#include<stdio.h>
#include<conio.h>
#include<malloc.h>
#include<math.h>

struct Sinhvien {
    int msv;
    char tensv[20];
    char lop[20];
    float diemtk;
    char hanhkiem[20]; 
};

struct Node {
    struct Sinhvien data;
    struct Node* left;
    struct Node* right;
};
typedef struct Node Node;


void KhoiTaoCay(Node** root) {
    *root = NULL;
}

Node* TaoNutMoi(struct Sinhvien sv) {
    Node* p = (Node*)malloc(sizeof(Node));
    p->data = sv;
    p->left = NULL;
    p->right = NULL;
    return p;
}

void ChenNut(Node** root, struct Sinhvien sv) {
    if (*root == NULL) {
        *root = TaoNutMoi(sv);
    } else {
        if (sv.msv < (*root)->data.msv) {
            ChenNut(&((*root)->left), sv);
        } else if (sv.msv > (*root)->data.msv) {
            ChenNut(&((*root)->right), sv);
        }
    }
}

Node* TimKiem(Node* root, int msv) {
    if (root == NULL) return NULL;
    
    if (root->data.msv == msv) {
        return root;
    }
    
    if (msv < root->data.msv) {
        return TimKiem(root->left, msv);
    } else {
        return TimKiem(root->right, msv);
    }
}

void HienThiTieuDe() {
    printf("\n|----------------------------------------------------------------------------------------------------------------------|");
    printf("\n|%-20s|%-20s|%-20s|%-20s|%-20s|", "Msv", "Tensv", "Lop", "Diemtk", "Hanh Kiem");
    printf("\n|----------------------------------------------------------------------------------------------------------------------|");
}

void InSinhVien(struct Sinhvien sv) {
    printf("\n|%-20d|%-20s|%-20s|%-20.2f|%-20s|", sv.msv, sv.tensv, sv.lop, sv.diemtk, sv.hanhkiem);
}

void DuyetCay(Node* root) {
    if (root != NULL) {
        DuyetCay(root->left);
        InSinhVien(root->data);
        DuyetCay(root->right);
    }
}

int main() {
    Node* root;
    KhoiTaoCay(&root);
    int n;

    do {
        printf("\nNhap So sinh vien: ");
        scanf("%d", &n);
    } while (n <= 0);

    printf("\nNhap sinh vien: \n");
    for (int i = 0; i < n; i++) {
        struct Sinhvien sv;
        printf("\nThong tin sinh vien thu: %d", i + 1);
        printf("\nNhap msv: "); fflush(stdin); scanf("%d", &sv.msv);
        printf("\nNhap tensv: "); fflush(stdin); gets(sv.tensv);
        printf("\nNhap lop: "); fflush(stdin); gets(sv.lop);
        printf("\nNhap diemtk: "); fflush(stdin); scanf("%f", &sv.diemtk);
        printf("\nNhap hanh kiem: "); fflush(stdin); gets(sv.hanhkiem);
        
        ChenNut(&root, sv);
    }

    printf("\n\nHien thi danh sach sinh vien trong cay: \n");
    HienThiTieuDe();
    DuyetCay(root);
    printf("\n|----------------------------------------------------------------------------------------------------------------------|");

    int msvTimKiem;
    printf("\n\nNhap ma sinh vien can tim: ");
    scanf("%d", &msvTimKiem);
    
    Node* kq = TimKiem(root, msvTimKiem);
    if (kq != NULL) {
        printf("\nThong tin sinh vien tim thay:");
        HienThiTieuDe();
        InSinhVien(kq->data);
        printf("\n|----------------------------------------------------------------------------------------------------------------------|\n");
    } else {
        printf("\nKhong co sinh vien trong cay.\n");
    }

    return 0;
}
