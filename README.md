# Kogane Project Browser Internal

Project ビューの internal な機能を呼び出せるようにするクラス

## 使用例

```cs
using Kogane;
using UnityEditor;

public class Example
{
    [MenuItem( "Tools/Hoge" )]
    private static void Hoge()
    {
        // Project ビューでアセットを検索
        ProjectBrowserInternal.SetSearch( "ピカチュウ" );
    }
}
```